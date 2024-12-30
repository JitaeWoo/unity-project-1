using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI
{
    private Slider _hpBar;
    public PlayerHealthUI(Slider hpBar)
    {
        _hpBar = hpBar;
    }

    public void UpdateHealth(float current, float max)
    {
        _hpBar.maxValue = max;
        _hpBar.value = current;
    }
}
