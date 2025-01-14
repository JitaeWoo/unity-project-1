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

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I started!");
        _baseStats = ScriptableObject.CreateInstance<PlayerBaseStats>();
        _stats = new PlayerStats(_baseStats);
        _hp = new PlayerHealth(_stats.MaxHealth);
        _hpUI = new PlayerHealthUI(_hpBar);
        _movement = new PlayerMovement(this.transform);
        _inputHandler = new PlayerInputHandler();
        _damageHandler = new PlayerDamageHandler(_hp, _hpUI);
        _invincibilityManager = new PlayerInvincibilityManager(this, 0.5f);
        isControll = true;
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
