using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2.0f;
    private Transform _target;
    private bool _isMoving = false;

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
    }

    public void GoFairy(Transform target)
    {
        _target = target;
        _isMoving = true;
    }

    public void TeleportFairy(Transform target)
    {
        transform.position = target.position;
    }
}
