using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : IEnemyState
{
    private EnemyAIController _enemy;

    public EnemyChaseState(EnemyAIController enemy)
    {
        this._enemy = enemy;
    }
    public void Enter()
    {
        _enemy.MoveComponent.Move();
    }

    public void Update()
    {
        _enemy.MoveComponent.SetTarget(_enemy.Player);
        if (_enemy.IsPlayerInRange(_enemy.attackRadius))
        {
            _enemy.ChangeState(new EnemyAttackState(_enemy));
        }
    }

    public void Exit()
    {

    }
}
