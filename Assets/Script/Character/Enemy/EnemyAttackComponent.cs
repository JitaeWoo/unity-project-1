using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackComponent : MonoBehaviour, IDamageDealer
{
    [SerializeField] private GameObject _attackPrefab;
    [SerializeField] private GameObject _warningPrefab;
    [SerializeField] private float _warningDuration = 2f;
    [SerializeField] private float _attackCooldown = 1f;
    [SerializeField] private float _damage = 10f;
    public float Damage => _damage;
    public bool IsAttack {  get; private set; }

    public void Attack(Transform target)
    {
        IsAttack = true;

        StartCoroutine(ExecuteAttack(target.position));
    }

    public void EndAttack()
    {
        IsAttack = false;
    }

    private IEnumerator ExecuteAttack(Vector3 targetPosition)
    {
        GameObject warningObject = Instantiate(_warningPrefab, transform.position, Quaternion.Euler(0, 0, GetAngleToTarget(targetPosition)));
        warningObject.transform.parent = transform;
        Warning warning = warningObject.GetComponent<Warning>();
        warning.SetWarningDuration(_warningDuration);
        warning.StartWarning();

        yield return new WaitForSeconds(_warningDuration);

        GameObject attackObject = Instantiate(_attackPrefab, transform.position, Quaternion.Euler(0, 0, GetAngleToTarget(targetPosition)));
        attackObject.transform.parent = transform;
        IAttack attack = attackObject.GetComponent<IAttack>();
        attack.SetTarget(targetPosition);
        attack.StartAttack();


        yield return new WaitForSeconds(_attackCooldown);

        EndAttack();
    }

    private float GetAngleToTarget(Vector3 targetPosition)
    {
        Vector2 direction = (targetPosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        return angle;
    }
}
