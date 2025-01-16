using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float Current { get; private set; }
    public float Max { get; private set; }

    private void Start()
    {
        Max = GetComponent<PlayerStats>().MaxHealth;
        Current = Max;
    }

    public void TakeDamage(float damage)
    {
        Current = Mathf.Clamp(Current - damage, 0, Max);
        GamePlayUIManager.Instance.UpdateHealthUI(Current, Max);
    }

    public void Heal(float amount)
    {
        Current = Mathf.Clamp(Current + amount, 0, Max);
        GamePlayUIManager.Instance.UpdateHealthUI(Current, Max);
    }
}
