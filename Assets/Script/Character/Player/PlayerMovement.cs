using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _moveDirection;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_moveDirection != Vector2.zero)
        {
            transform.rotation = Quaternion.Euler(0, 0, transform.GetAngleToTarget(transform.position + (Vector3)_moveDirection));
        }
    }

    public void Move(Vector3 direction)
    {
        _moveDirection = direction;
    }

    private void FixedUpdate()
    {
        if (_moveDirection != Vector2.zero)
        {
            Vector3 CurrentPosition = _rb.position + _moveDirection * PlayerManager.Instance.Stats.Speed * Time.fixedDeltaTime;
            _rb.MovePosition(CurrentPosition);

            // 컷신에 들어가는 등 컨트롤을 강제로 못하게 해도 움직이지 않기 위한 조치
            _moveDirection = Vector2.zero;
        }
    }
}
