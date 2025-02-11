using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackComponent : MonoBehaviour, IDamageDealer
{
    // TODO : 적 스탯 모아 놓은 스크립트로 이동
    [SerializeField] private float _damage = 10f;
    public float Damage => _damage;
    public bool IsAttack {  get; private set; }

    private List<IAttack> _attackPrefabs = new List<IAttack>();

    private void Start()
    {
        foreach (Transform child in transform.Find("Attacks"))
        {
            IAttack attack = child.GetComponent<IAttack>();
            Debug.Log(attack);
            if (attack != null)
            {
                _attackPrefabs.Add(attack);
            }
        }
    }

    public void Attack(Transform target)
    {
        IsAttack = true;

        StartCoroutine(ExecuteAttack(target));
    }

    public void EndAttack()
    {
        IsAttack = false;
    }

    private IEnumerator ExecuteAttack(Transform target)
    {
        int randomIndex = Random.Range(0, _attackPrefabs.Count);
        _attackPrefabs[randomIndex].SetTarget(target);
        _attackPrefabs[randomIndex].StartAttack();

        yield return new WaitForSeconds(_attackPrefabs[randomIndex].GetAttackDuration());

        EndAttack();
    }
}
