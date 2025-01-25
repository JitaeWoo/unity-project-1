using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IDamageDealer, IAttack
{
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _speed = 5f; 
    [SerializeField] private float _lifetime = 3f;
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

    public void SetTarget(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
    }

    public void StartAttack()
    {
        Destroy(gameObject, _lifetime);
    }
}
