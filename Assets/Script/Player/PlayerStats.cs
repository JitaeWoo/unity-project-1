using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    public float Speed { get; private set; }
    public float Damage { get; private set; }
    public float MaxHealth { get; private set; }

    public PlayerStats(PlayerBaseStats baseStats)
    {
        Speed = baseStats.baseSpeed;
        Damage = baseStats.baseDamage;
        MaxHealth = baseStats.baseMaxHealth;
    }

    public void LevelUp()
    {
        MaxHealth += 10f;
        Damage += 2f;
        Speed += 0.5f;
    }
}
