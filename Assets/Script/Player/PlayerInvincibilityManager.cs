using System;
using System.Collections;
using UnityEngine;

public class PlayerInvincibilityManager
{
    public bool IsInvincible { get; private set; }
    private float _invincibleDuration;
    private PlayerController _player;

    public event Action OnInvincibilityStart; // 무적 상태 시작 이벤트
    public event Action OnInvincibilityEnd;   // 무적 상태 종료 이벤트


    public PlayerInvincibilityManager(PlayerController player, float invincibleDuration)
    {
        _player = player;
        _invincibleDuration = invincibleDuration;
    }

    public void StartInvincibility()
    {
        if (IsInvincible) return;

        IsInvincible = true;
        OnInvincibilityStart?.Invoke(); // 무적 상태 시작 알림
        _player.StartCoroutine(InvincibilityCoroutine());
    }

    private IEnumerator InvincibilityCoroutine()
    {
        yield return new WaitForSeconds(_invincibleDuration);
        IsInvincible = false;
        OnInvincibilityEnd?.Invoke(); // 무적 상태 종료 알림
    }
}
