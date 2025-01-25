using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAIController : MonoBehaviour
{
    public EnemyHealthComponent HealthComponent {  get; private set; }
    public EnemyMoveComponent MoveComponent { get; private set; }
    public EnemyAttackComponent AttackComponent { get; private set; }
    public Transform Player;
    private IEnemyState _currentState;
    public float detectionRadius = 10f; 
    public float attackRadius = 2f;

    private void Awake()
    {
        HealthComponent = GetComponent<EnemyHealthComponent>();
        MoveComponent = GetComponent<EnemyMoveComponent>();
        AttackComponent = GetComponent<EnemyAttackComponent>();
        ChangeState(new EnemyIdleState(this));
    }

        private void Start()
    {
        Player = PlayerManager.Instance.transform;
    }

    private void Update()
    {
        _currentState?.Update();
    }

    public void ChangeState(IEnemyState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    public bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, Player.position) <= range;
    }
}
