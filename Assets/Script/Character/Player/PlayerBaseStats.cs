using UnityEngine;

[CreateAssetMenu(fileName = "PlayerBaseStats", menuName = "Game/Player Base Stats")]
public class PlayerBaseStats : ScriptableObject
{
    public float baseSpeed = 5f;
    public float baseDamage = 10f;
    public float baseMaxHealth = 100f;
}
