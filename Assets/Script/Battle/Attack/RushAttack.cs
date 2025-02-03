using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushAttack : MonoBehaviour, IAttack
{
    [SerializeField] private GameObject _warningPrefab;
    [SerializeField] private float _warningDuration = 2f;
    [SerializeField] private AnimationClip _rushAnimation;
    [SerializeField] private float _rushRange = 5f;
    [SerializeField] private float _rushDuration = 1f;
    private Transform _attacker;
    private Rigidbody2D _rb;
    private Vector3 _targetPosition;
    private Vector3 _currentPosition;
    private bool _isRush;

    private void Start()
    {
        // [Attacker/Attacks/현재 어택 프리팹]의 오브젝트 구조를 가진다고 여깁니다.
        _attacker = transform.parent.parent;
        _rb = _attacker.GetComponent<Rigidbody2D>();
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
        if(_rushAnimation != null)
        {
            Animator animator = _attacker.GetComponent<Animator>();
            animator.Play(_rushAnimation.name);
        }

        GameObject warningObject = Instantiate(_warningPrefab, transform.position, Quaternion.Euler(0, 0, transform.GetAngleToTarget(_targetPosition)));
        IWarning warning = warningObject.GetComponent<IWarning>();
        warning.SetWarningDuration(_warningDuration);
        warning.SetWarningSize(new Vector2(_rushRange, 1));
        warning.StartWarning();

        yield return new WaitForSeconds(_warningDuration);

        Vector3 direction = (_targetPosition - _attacker.position).normalized;
        Vector3 rushPoint = _attacker.position + direction * _rushRange;

        _currentPosition = _attacker.position; // FixedUpdate 실행 전 _currentPosiont 초기화
        _isRush = true;
        DOTween.To(
            () => _attacker.position,
            x => _currentPosition = x,
            rushPoint,
            _rushDuration
        )
        .SetEase(Ease.OutQuad)
        .OnComplete(() =>
        {
            _isRush = false; 
        });
    }

    private void FixedUpdate()
    {
        if (_isRush)
        {
            _rb.MovePosition(_currentPosition);
        }
    }
}
