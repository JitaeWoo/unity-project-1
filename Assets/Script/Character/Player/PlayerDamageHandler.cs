using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    [SerializeField] private AudioClip _onDamagedAudio;
    void OnTriggerStay2D(Collider2D other)
    {
        IDamageDealer damageDealer = other.GetComponentInParent<IDamageDealer>();
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
        float finalDamage = damage; // 데미지 형식이나 방어력 등이 추가되면 수정 예정

        SoundManager.Instance.PlaySFX(_onDamagedAudio);
        Debug.Log($"Player get damage {finalDamage}");
        PlayerManager.Instance.Health.TakeDamage(finalDamage);
    }
}
