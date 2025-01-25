using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyMoveComponent : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 _direction = Vector3.zero;
    private bool _isMoving = false;

    private void Update()
    {
        if (_isMoving)
        {
            transform.Translate(_direction * _speed * Time.deltaTime);
        }
    }

    public void SetTarget(Transform target)
    {
        _direction = (target.position - transform.position).normalized;
    }

    public void Stop()
    {
        _isMoving = false;
    }

    public void Move()
    {
        _isMoving = true;
    }

    public void Charge(Transform target)
    {
        transform.DOMove(target.position, 2f).SetEase(Ease.OutQuad);
    }
}
