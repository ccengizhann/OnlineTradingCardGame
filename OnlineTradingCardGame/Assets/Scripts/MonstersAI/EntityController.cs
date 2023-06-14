using UnityEngine;


public class EntityController : MonoBehaviour
{
    private StateMachine _stateMachine;
    public Animator Animator;
    
    [SerializeField] private StateType _currentState;
    [SerializeField] private StateType _nextState;

    [SerializeField] private Transform _currentTarget;
    [SerializeField] private Transform _nextTarget;
    
    private AIMove _monster;
    private void Awake()
    {
        _stateMachine = new StateMachine();
        Animator = GetComponent<Animator>();
    }

    void Start()
    {
        IState idleState = new IdleState(this);
        IState walkState = new WalkState(this);
        IState attackState = new AttackState(this);

        _stateMachine.SetNormalStates(idleState, walkState, () => _currentState == StateType.Walk &&
                                                                  Vector3.Distance(transform.position, _currentTarget.position) < 1f);
        
        _stateMachine.SetNormalStates(walkState, idleState, () => _currentState == StateType.Idle &&
                                                                  Vector3.Distance(transform.position, _currentTarget.position) < 1f);
        
        _stateMachine.SetNormalStates(walkState,attackState, () => _currentState == StateType.Attack &&
                                                      Vector3.Distance(transform.position, _currentTarget.position) < 1f);
        
        _stateMachine.SetAnyStates(walkState, () => Vector3.Distance(_currentTarget.position, transform.position) > 1f);
        
        _stateMachine.SetState(idleState);
    }

    public void SetStateType(AIMove aiMove)
    {
        _currentState = aiMove.CurrentStateType;
        _nextState = aiMove.NextStateType;
        _currentTarget = aiMove.CurrentTarget;
        _nextTarget = aiMove.NextTarget;
    }
    
    void Update()
    {
        _stateMachine.Tick();
    }

    public void ChangeState()
    {
        _currentState = _nextState;
        _currentTarget = _nextTarget;
    }
}