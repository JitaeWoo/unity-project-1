using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO : ProjectileShot 등의 이름으로 바꾸고 로직 개편 (가능하다면)
public class StoneFall : MonoBehaviour, IAttack
{
    [SerializeField] private GameObject _warningPrefab;
    [SerializeField] private GameObject _stonePrefab;
    [SerializeField] private float _warningDuration = 2f;
    [SerializeField] private Vector2 _stoneSize = Vector2.one;
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _lifeTime = 5f;

    private Vector3 _targetPosition;
    public void SetTarget(Transform target)
    {
        _targetPosition = target.position;
    }

    public float GetAttackDuration()
    {
        return _warningDuration + _lifeTime + 1f;
    }

    public void StartAttack()
    {
        StartCoroutine(FallStone());
    }

    private IEnumerator FallStone()
    {
        GameObject warningObject = Instantiate(_warningPrefab, transform);
        IWarning warning = warningObject.GetComponent<IWarning>();
        warning.SetWarningDuration(_warningDuration);
        warning.SetWarningSize(_stoneSize);
        warning.StartWarning();

        yield return new WaitForSeconds(_warningDuration);

        GameObject stone = Instantiate(_stonePrefab, transform);
        stone.transform.localScale = _stoneSize;
        Projectile projectile = stone.GetComponent<Projectile>();
        projectile.SetProjectileProperties(_damage, 0f, _lifeTime);
        projectile.ShotProjectile();
    }
}
