using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    // 2D 캐릭터가 특정 타겟 방향을 바라보도록 하기 위해 사용
    // 예 : Quaternion.Euler(0, 0, transform.GetAngleToTarget(_targetPosition))
    public static float GetAngleToTarget(this Transform fromTransform, Vector3 targetPosition)
    {
        Vector2 direction = (targetPosition - fromTransform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        return angle;
    }
}
