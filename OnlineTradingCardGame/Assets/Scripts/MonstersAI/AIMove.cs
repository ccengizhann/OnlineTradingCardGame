using UnityEngine;

public class AIMove : MonoBehaviour
{
    //TODO: target bilgisi cardslot'dan red/blue team gibi ayrimlarla yollanacak
    //player blue, enemy red gibi...
    
    public Transform target;
    public Transform spawn;

    public StateType CurrentStateType;
    public StateType NextStateType;
    public Transform CurrentTarget;
    public Transform NextTarget;

    private EntityController _controller;

    private void Awake()
    {
        _controller = GetComponent<EntityController>();
        CurrentStateType = StateType.Idle;
        NextStateType = StateType.Idle;
        spawn = transform;
        CurrentTarget = spawn;
        NextTarget = spawn;
    }

    private void Start()
    {
        _controller.SetStateType(this);
    }

    private void Update()
    {
        //TODO: monsterlarin karar mekanizmasi yazilacak...
        
        
    }
}
