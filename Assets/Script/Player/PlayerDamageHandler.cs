using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHandler
{
    private PlayerHealth _health;
    private PlayerHealthUI _healthUI;

    public PlayerDamageHandler(PlayerHealth health, PlayerHealthUI healthUI)
    {
        _health = health;
        _healthUI = healthUI;
    }

    public void HandleDamage(Collider2D other, bool isInvincible)
    {
        if (isInvincible) // 회피 불가 공격 같은거 나오면 수정 예정
            return;

        IDamageDealer damageDealer = other.GetComponent<IDamageDealer>();
        if (damageDealer != null)
        {
            ApplyDamage(damageDealer.Damage);
        }
    }

    private void ApplyDamage(float damage)
    {
        float finalDamage = damage;

        _health.TakeDamage(finalDamage);
        _healthUI.UpdateHealth(_health.Current, _health.Max);
    }
}
