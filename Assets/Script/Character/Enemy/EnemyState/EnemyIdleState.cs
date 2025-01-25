using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : IEnemyState
{
    private EnemyAIController _enemy;

    public EnemyIdleState(EnemyAIController enemy)
    {
        this._enemy = enemy;
    }

    public void Enter()
    {
        _enemy.MoveComponent.Stop();
    }

    public void Update()
    {
        if (_enemy.IsPlayerInRange(_enemy.detectionRadius))
        {
            _enemy.ChangeState(new EnemyChaseState(_enemy));
        }
    }

    public void Exit()
    {
    }
}
