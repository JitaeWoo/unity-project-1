using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredTrapHandler : MonoBehaviour
{
    [SerializeField] private bool _isLoop;
    private List<IAttack> _attackPrefabs = new List<IAttack>();
    private bool _isTriggered = false;

    private void Start()
    {
        foreach (Transform child in transform.Find("Attacks"))
        {
            IAttack attack = child.GetComponent<IAttack>();
            if (attack != null)
            {
                _attackPrefabs.Add(attack);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(!_isTriggered)
            {
                _isTriggered = true;
                StartCoroutine(ExecuteAttack(other.transform));
            }
            
        }
    }

    private IEnumerator ExecuteAttack(Transform target)
    {
        int randomIndex = Random.Range(0, _attackPrefabs.Count);
        _attackPrefabs[randomIndex].SetTarget(target);
        _attackPrefabs[randomIndex].StartAttack();

        yield return new WaitForSeconds(_attackPrefabs[randomIndex].GetAttackDuration());

        if (!_isLoop)
        {
            gameObject.SetActive(false);
        }

        _isTriggered = false;
    }
}
