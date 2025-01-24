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

        // �̵�: �÷��̾ ����
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        moveComponent.SetDirection(directionToPlayer);

        // ����: �÷��̾���� �Ÿ� Ȯ�� �� �õ�
        attackComponent.TryAttack(player);
    }
}
