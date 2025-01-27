using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    void SetTarget(Transform target);
    float GetAttackDuration();
    void StartAttack();
}
