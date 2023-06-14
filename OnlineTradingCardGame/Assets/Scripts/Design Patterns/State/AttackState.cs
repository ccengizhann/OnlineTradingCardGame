using UnityEngine;

public class AttackState : IState
{
    private readonly EntityController _entityController;
    private readonly float _maxTime = 3f;
    private float _currentTime = 0f;

    public AttackState(EntityController entityController)
    {
        _entityController = entityController;
    }
    
    public void Enter()
    {
        _entityController.Animator.SetBool("isAttack", true);    
    }

    public void Exit()
    {
        _currentTime = 0f;
        _entityController.Animator.SetBool("isAttack", false);
    }

    public void Tick()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > _maxTime)
        {
            _entityController.ChangeState();
        }
    }
}