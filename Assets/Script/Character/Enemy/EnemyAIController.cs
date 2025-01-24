using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIController : MonoBehaviour
{
    private EnemyHealthComponent healthComponent;
    private EnemyMoveComponent moveComponent;
    private EnemyAttackComponent attackComponent;
    private Transform player;

    private void Awake()
    {
        healthComponent = GetComponent<EnemyHealthComponent>();
        moveComponent = GetComponent<EnemyMoveComponent>();
        attackComponent = GetComponent<EnemyAttackComponent>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player == null) return;

        // 이동: 플레이어를 추적
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        moveComponent.SetDirection(directionToPlayer);

        // 공격: 플레이어와의 거리 확인 후 시도
        attackComponent.TryAttack(player);
    }
}
