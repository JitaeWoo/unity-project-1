using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushAttack : MonoBehaviour, IAttack
{
    [SerializeField] private float _rushRange = 5f;

    private Vector3 _targetPosition;
    public void SetTarget(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
    }

    public void StartAttack()
    {
        Vector3 direction = (_targetPosition - transform.parent.position).normalized;
        Vector3 targetPosition = transform.parent.position + direction * _rushRange;
        Rigidbody2D rb = transform.parent.GetComponent<Rigidbody2D>();

        rb.DOMove(targetPosition, 1f).SetEase(Ease.OutQuad).OnComplete(() =>
        {
            Destroy(this.gameObject);
        });
    }
}
