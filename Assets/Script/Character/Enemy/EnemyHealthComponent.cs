using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthComponent : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    public void Die()
    {
        // TODO : �׾��� �� �ִϸ��̼� ���� ȿ�� �߰�
        // TODO : ����ġ ���� ���� �߰�
        gameObject.SetActive(false);
    }
}
