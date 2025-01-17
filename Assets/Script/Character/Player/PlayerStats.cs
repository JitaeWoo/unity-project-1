using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour 
{
    [SerializeField] PlayerBaseStats _baseStats;
    [SerializeField] public float Speed { get; private set; }
    [SerializeField] public float Damage { get; private set; }
    [SerializeField] public float MaxHealth { get; private set; }

    private void Awake()
    {
        Speed = _baseStats.baseSpeed;
        Damage = _baseStats.baseDamage;
        MaxHealth = _baseStats.baseMaxHealth;
    }
}
