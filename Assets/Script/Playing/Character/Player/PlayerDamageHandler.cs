using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    private PlayerInvincibilityManager _invincibilityManager;
    private void Awake()
    {
        _invincibilityManager = GetComponent<PlayerInvincibilityManager>();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        HandleDamage(other, _invincibilityManager.IsInvincible);

        if (!_invincibilityManager.IsInvincible)
        {
            _invincibilityManager.StartInvincibility();
        }
    }

    public void HandleDamage(Collider2D other, bool isInvincible)
    {
        if (isInvincible) // ȸ�� �Ұ� ���� ������ ������ ���� ����
            return;

        IDamageDealer damageDealer = other.GetComponent<IDamageDealer>();
        if (damageDealer != null)
        {
            ApplyDamage(damageDealer.Damage);
        }
    }

    private void ApplyDamage(float damage)
    {
        float finalDamage = damage; // ������ �����̳� ���� ���� �߰��Ǹ� ���� ����

        transform.GetComponent<PlayerHealth>().TakeDamage(finalDamage);
    }
}
