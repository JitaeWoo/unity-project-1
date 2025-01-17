using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IDamageDealer
{
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _speed = 5f; 
    [SerializeField] private float _lifetime = 3f; 

    public float Damage => _damage;

    private void Start()
    {
        Destroy(gameObject, _lifetime);
    }

    private void Update()
    {
        // 직선 이동
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }
}
