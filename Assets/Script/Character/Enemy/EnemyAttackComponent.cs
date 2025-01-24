using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackComponent : MonoBehaviour
{
    [SerializeField] private float attackRange;
    [SerializeField] private float attackDamage;
    [SerializeField] private float attackCooldown;
    private float lastAttackTime;

    public void TryAttack(Transform target)
    {
        if (Time.time - lastAttackTime < attackCooldown) return;

        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= attackRange)
        {
            // ���� ����
            Debug.Log($"{gameObject.name}��(��) {target.name}��(��) �����մϴ�!");
            lastAttackTime = Time.time;
        }
    }
}
