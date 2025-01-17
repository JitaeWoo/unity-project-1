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
        if (isInvincible) // 회피 불가 공격 같은거 나오면 수정 예정
            return;
        
        ApplyDamage(damage);
        PlayerManager.Instance.InvincibilityManager.StartInvincibility();
    }

    private void ApplyDamage(float damage)
    {
        float finalDamage = damage; // 데미지 형식이나 방어력 등이 추가되면 수정 예정

        PlayerManager.Instance.Health.TakeDamage(finalDamage);
    }
}
