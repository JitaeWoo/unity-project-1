using System;
using System.Collections;
using UnityEngine;

public class PlayerInvincibilityManager
{
    public bool IsInvincible { get; private set; }
    private float _invincibleDuration;
    private PlayerController _player;

    public event Action OnInvincibilityStart; // ���� ���� ���� �̺�Ʈ
    public event Action OnInvincibilityEnd;   // ���� ���� ���� �̺�Ʈ


    public PlayerInvincibilityManager(PlayerController player, float invincibleDuration)
    {
        _player = player;
        _invincibleDuration = invincibleDuration;
    }

    public void StartInvincibility()
    {
        if (IsInvincible) return;

        IsInvincible = true;
        OnInvincibilityStart?.Invoke(); // ���� ���� ���� �˸�
        _player.StartCoroutine(InvincibilityCoroutine());
    }

    private IEnumerator InvincibilityCoroutine()
    {
        yield return new WaitForSeconds(_invincibleDuration);
        IsInvincible = false;
        OnInvincibilityEnd?.Invoke(); // ���� ���� ���� �˸�
    }
}
