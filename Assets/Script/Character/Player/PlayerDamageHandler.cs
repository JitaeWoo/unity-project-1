using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        IDamageDealer damageDealer = other.GetComponent<IDamageDealer>();
        if (damageDealer != null)
        {
            HandleDamage(damageDealer.Damage, PlayerManager.Instance.InvincibilityManager.IsInvincible);
        }
    }

    public void HandleDamage(float damage, bool isInvincible)
    {
        if (isInvincible) // ȸ�� �Ұ� ���� ������ ������ ���� ����
            return;
        
        ApplyDamage(damage);
        PlayerManager.Instance.InvincibilityManager.StartInvincibility();
    }

    private void ApplyDamage(float damage)
    {
        float finalDamage = damage; // ������ �����̳� ���� ���� �߰��Ǹ� ���� ����

        PlayerManager.Instance.Health.TakeDamage(finalDamage);
    }
}
