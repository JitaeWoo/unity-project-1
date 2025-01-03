using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private PlayerBaseStats _baseStats;
    [SerializeField] private Slider _hpBar;
    private PlayerStats _stats;
    private PlayerHealth _hp;
    private PlayerHealthUI _hpUI;
    private PlayerMovement _movement;
    private PlayerInputHandler _inputHandler;
    private PlayerDamageHandler _damageHandler;
    private PlayerInvincibilityManager _invincibilityManager;
    private bool isControll;

    public void Initialize(PlayerStats stats, PlayerHealth hp, PlayerHealthUI hpUI, PlayerMovement movement, PlayerInputHandler inputHandler, PlayerDamageHandler damageHandler, PlayerInvincibilityManager invincibilityManager)
    {
        Debug.Log("I initialized!");
        _stats = stats;
        _hp = hp;
        _hpUI = hpUI;
        _movement = movement;
        _inputHandler = inputHandler;
        _damageHandler = damageHandler;
        _invincibilityManager = invincibilityManager;
        isControll = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I started!");
    }

    // Update is called once per frame
    void Update()
    {
        if (isControll)
        {
            Vector3 direction = _inputHandler.GetMovementInput();
            _movement.Move(direction, _stats.Speed);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        _damageHandler.HandleDamage(other, _invincibilityManager.IsInvincible);

        if (!_invincibilityManager.IsInvincible)
        {
            _invincibilityManager.StartInvincibility();
        }
    }

    public void SetIsControll(bool set)
    {
        isControll = set;
    }
}
