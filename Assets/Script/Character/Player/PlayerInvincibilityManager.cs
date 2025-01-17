using System;
using System.Collections;
using UnityEngine;

public class PlayerInvincibilityManager : MonoBehaviour
{
    [SerializeField] private float _invincibleDuration = 0.5f;
    public bool IsInvincible { get; private set; }

    public event Action OnInvincibilityStart; // 무적 상태 시작 이벤트
    public event Action OnInvincibilityEnd;   // 무적 상태 종료 이벤트

    public void StartInvincibility()
    {
        if (IsInvincible) return;

        IsInvincible = true;
        OnInvincibilityStart?.Invoke(); // 무적 상태 시작 알림
        StartCoroutine(InvincibilityCoroutine());
    }

    private IEnumerator InvincibilityCoroutine()
    {
        yield return new WaitForSeconds(_invincibleDuration);
        IsInvincible = false;
        OnInvincibilityEnd?.Invoke(); // 무적 상태 종료 알림
    }
}
