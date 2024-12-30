using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private Slider _hpBar;
    private PlayerHealth _hp;
    private PlayerHealthUI _hpUI;
    private PlayerMovement _movement;
    private PlayerInputHandler _inputHandler;
    private PlayerDamageHandler _damageHandler;
    private float _speed;

    public float damage;
    private float invicibleTime;
    private bool isInvincible;
    private bool isControll;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I started!");
        _hp = new PlayerHealth(100);
        _hpUI = new PlayerHealthUI(_hpBar);
        _movement = new PlayerMovement(transform);
        _inputHandler = new PlayerInputHandler();
        _damageHandler = new PlayerDamageHandler(_hp, _hpUI);

        _speed = 5f;
        damage = 10f;
        invicibleTime = 0.5f;
        isInvincible = false;
        isControll = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isControll)
        {
            Vector3 direction = _inputHandler.GetMovementInput();
            _movement.Move(direction, _speed);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        _damageHandler.HandleDamage(other, isInvincible);
    }

    private IEnumerator InvincibleDuration(float ITime)
    {
        isInvincible = true;

        yield return new WaitForSeconds(ITime);

        isInvincible = false;
    }

    public void SetIsControll(bool set)
    {
        isControll = set;
    }
}
