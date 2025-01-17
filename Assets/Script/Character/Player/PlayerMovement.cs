using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _movementSpeed;

    private void Awake()
    {
        _movementSpeed = GetComponent<PlayerStats>().Speed;
    }

    public void Move(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            // ��ġ �̵�
            transform.position += direction * _movementSpeed * Time.deltaTime;

            // ȸ�� ó��
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
    }
}
