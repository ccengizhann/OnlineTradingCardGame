using UnityEngine;

public class WalkState : IState
{
    private readonly EntityController _entityController;
    private readonly float _maxTime = 5f;
    private float _currentTime = 0f;

    public WalkState(EntityController entityController)
    {
        _entityController = entityController;
    }
    
    public void Enter()
    {
        _entityController.Animator.SetBool("isWalk", true);    
    }

    public void Exit()
    {
        _currentTime = 0f;
        _entityController.Animator.SetBool("isWalk", false);
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