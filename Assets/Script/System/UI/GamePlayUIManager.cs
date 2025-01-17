using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUIManager : Singleton<GamePlayUIManager>
{
    private Slider _hpBar;

    private void Start()
    {
        _hpBar = GetComponentInChildren<Slider>();
    }
    public void UpdateHealthUI(float current, float max)
    {
        _hpBar.maxValue = max;
        _hpBar.value = current;
    }
}
