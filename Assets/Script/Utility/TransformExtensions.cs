using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    // 2D ĳ���Ͱ� Ư�� Ÿ�� ������ �ٶ󺸵��� �ϱ� ���� ���
    // �� : Quaternion.Euler(0, 0, transform.GetAngleToTarget(_targetPosition))
    public static float GetAngleToTarget(this Transform fromTransform, Vector3 targetPosition)
    {
        Vector2 direction = (targetPosition - fromTransform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        return angle;
    }
}
