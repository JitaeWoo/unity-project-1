using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IDamageDealer
{
    private float _damage = 10f;
    private float _speed = 5f; 
    private float _lifetime = 3f;
    private Vector3 _targetPosition;

    public float Damage => _damage;

    private void Update()
    {
        if(_targetPosition == null)
        {
            return;
        }

        Vector2 direction = (transform.position - _targetPosition).normalized;

        transform.Translate(direction * _speed * Time.deltaTime);
    }

    public void SetTarget(Transform target)
    {
        _targetPosition = target.position;
    }

    public void SetProjectileProperties(float damage, float speed, float lifetime)
    {
        _damage = damage;
        _speed = speed;
        _lifetime = lifetime;
    }

    public void ShotProjectile()
    {
        Destroy(gameObject, _lifetime);
    }
}
