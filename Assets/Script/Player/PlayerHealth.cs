using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth
{
    public float Current { get; private set; }
    public float Max { get; private set; }

    public PlayerHealth(float max)
    {
        Current = max;
        Max = max;
    }

    public void TakeDamage(float damage)
    {
        Current = Mathf.Clamp(Current - damage, 0, Max);
    }

    public void Heal(float amount)
    {
        Current = Mathf.Clamp(Current + amount, 0, Max);
    }
}
