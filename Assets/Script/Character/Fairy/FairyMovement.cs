using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _stoppingDistance = 2f;
    private Transform _target;
    private bool _isMoving = false;
    private bool _isFollowing = false;

    void Update()
    {
        if (_isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

            if(transform.position == _target.position )
            {
                _isMoving = false;
            }
        }
        else if(_isFollowing) 
        {
            float distance = Vector2.Distance(transform.position, _target.position);

            if (distance > _stoppingDistance)
            {
                Vector2 direction = (_target.position - transform.position).normalized;
                transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
            }
        }
    }

    public void Go(Transform target)
    {
        _target = target;
        _isMoving = true;
    }

    public void FollowPlayer()
    {
        _target = PlayerManager.Instance.transform;
        _isFollowing = true;
    }

    public void StopFollow()
    {
        _isFollowing = false;
    }

    public void Teleport(Transform target)
    {
        transform.position = target.position;
    }
}
