using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    private Transform _transform;

    public PlayerMovement(Transform transform)
    {
        _transform = transform;
    }

    public void Move(Vector3 direction, float speed)
    {
        if (direction != Vector3.zero)
        {
            // ��ġ �̵�
            _transform.position += direction * speed * Time.deltaTime;

            // ȸ�� ó��
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
    }
}
