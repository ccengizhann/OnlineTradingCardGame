using UnityEngine;

public class IdleState : IState
{
    private readonly EntityController _entityController;
    private readonly float _maxTime = 10f;
    private float _currentTime = 0f;

    public IdleState(EntityController entityController)
    {
        _entityController = entityController;
    }
    
    public void Enter()
    {
        _entityController.Animator.SetBool("isIdle", true);    
    }

    public void Exit()
    {
        _currentTime = 0f;
        _entityController.Animator.SetBool("isIdle", false);
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