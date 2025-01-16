using System;
using System.Collections;
using UnityEngine;

public class PlayerInvincibilityManager : MonoBehaviour
{
    [SerializeField] private float _invincibleDuration = 0.5f;
    public bool IsInvincible { get; private set; }
    private PlayerController _player;

    public event Action OnInvincibilityStart; // ���� ���� ���� �̺�Ʈ
    public event Action OnInvincibilityEnd;   // ���� ���� ���� �̺�Ʈ

    private void Awake()
    {
        _player = GetComponent<PlayerController>();
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
