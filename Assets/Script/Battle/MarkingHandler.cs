using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarkingHandler : MonoBehaviour
{
    [SerializeField] private Image Fill;
    private float _playerDamage;
    private float _targetHealth;
    private float _killProgress;

    private void Start()
    {
        _playerDamage = PlayerManager.Instance.Stats.Damage;
        _targetHealth = transform.parent.GetComponent<IMarkable>().Health;
        Fill.fillAmount = 0;
        _killProgress = 0;
    }

    private void Update()
    {
        if(_killProgress / _targetHealth < 1)
        {
            _killProgress += _playerDamage * Time.deltaTime;
            Fill.fillAmount = _killProgress / _targetHealth;
        }
        else
        {
            if (Input.GetButtonDown("Kill"))
            {
                transform.parent.GetComponent<IMarkable>().Die();
                PlayerManager.Instance.Marking.ClearCurrentMark();
            }
        }
    }

}
