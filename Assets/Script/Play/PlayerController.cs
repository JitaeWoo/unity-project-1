using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private Slider _hpBar;
    private Vector3 direction = Vector3.zero;
    public int speed;
    private float _hp;
    public float damage;
    private float invicibleTime;
    private bool isInvincible;
    private bool isControll;

    public float Hp
    {
        get => _hp;
        private set => _hp = Math.Clamp(value, 0, _hp);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I started!");
        _hp = 100;
        SetMaxHealth(_hp);
        damage = 10f;
        invicibleTime = 0.5f;
        isInvincible = false;
        isControll = true;
    }

    public void SetMaxHealth(float health)
    {
        _hpBar.maxValue = health;
        _hpBar.value = health;
    }

    public void GetDamage(float damage)
    {
        Hp -= damage;
        _hpBar.value = Hp;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        direction = new Vector3(x, y, 0);

        if(direction != Vector3.zero && isControll){
            transform.position += direction * speed * Time.deltaTime;
            
            float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
        }


    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("DamageAble"))
        {
            if(!isInvincible){
                DamageAble curDamage = other.gameObject.GetComponent<DamageAble>();
                GetDamage(curDamage.damage);
                StartCoroutine(InvincibleDuration(invicibleTime));
            }
        }
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
