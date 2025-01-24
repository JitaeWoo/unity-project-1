using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveComponent : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 direction;

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
