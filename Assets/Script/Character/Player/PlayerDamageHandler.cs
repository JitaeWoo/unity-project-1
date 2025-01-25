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
            HandleDamage(damageDealer.Damage);
        }
    }

    public void HandleDamage(float damage)
    {
        if(PlayerManager.Instance.StateManager.CurrentState == PlayerState.Alive)
        {
            ApplyDamage(damage);
            if(PlayerManager.Instance.StateManager.CurrentState == PlayerState.Alive)
            {
                PlayerManager.Instance.StateManager.ChangeState(PlayerState.Invincible);
            }
        }
        else if (PlayerManager.Instance.StateManager.CurrentState == PlayerState.Invincible)
        {
            return;
        }
    }

    private void ApplyDamage(float damage)
    {
        float finalDamage = damage; // ������ �����̳� ���� ���� �߰��Ǹ� ���� ����

        Debug.Log($"Player get damage {finalDamage}");
        PlayerManager.Instance.Health.TakeDamage(finalDamage);
    }
}
