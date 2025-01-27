using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushAttack : MonoBehaviour, IAttack
{
    [SerializeField] private GameObject _warningPrefab;
    [SerializeField] private float _warningDuration = 2f;
    [SerializeField] private float _rushRange = 5f;
    [SerializeField] private float _rushDuration = 1f;
    private Transform _attacker;
    private Vector3 _targetPosition;

    private void Start()
    {
        _attacker = transform.parent.parent;   
    }


    public void SetTarget(Transform target)
    {
        _targetPosition = target.position;
    }

    public float GetAttackDuration()
    {
        return _warningDuration + _rushDuration + 1f;
    }

    public void StartAttack()
    {
        StartCoroutine(StartRush());
    }

    private IEnumerator StartRush()
    {
        GameObject warningObject = Instantiate(_warningPrefab, transform.position, Quaternion.Euler(0, 0, transform.GetAngleToTarget(_targetPosition)));
        IWarning warning = warningObject.GetComponent<IWarning>();
        warning.SetWarningDuration(_warningDuration);
        warning.SetWarningSize(new Vector2(_rushRange, 1));
        warning.StartWarning();

        yield return new WaitForSeconds(_warningDuration);

        Vector3 direction = (_targetPosition - _attacker.position).normalized;
        Vector3 targetPosition = _attacker.position + direction * _rushRange;
        Rigidbody2D rb = _attacker.GetComponent<Rigidbody2D>();

        rb.DOMove(targetPosition, _rushDuration).SetEase(Ease.OutQuad);
    }
}
