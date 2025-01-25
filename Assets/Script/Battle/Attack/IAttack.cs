using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    void SetTarget(Vector3 targetPosition);
    void StartAttack();
}
