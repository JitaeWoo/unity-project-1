using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : IEnemyState
{
    private EnemyAIController _enemy;

    public EnemyAttackState(EnemyAIController enemy)
    {
        this._enemy = enemy;
    }
    public void Enter()
    {
        _enemy.MoveComponent.Stop();
        _enemy.AttackComponent.Attack(_enemy.Player);
    }

    public void Update()
    {
        if (!_enemy.AttackComponent.IsAttack)
        {
            _enemy.ChangeState(new EnemyChaseState(_enemy));
        }
    }

    public void Exit()
    {

    }
}
