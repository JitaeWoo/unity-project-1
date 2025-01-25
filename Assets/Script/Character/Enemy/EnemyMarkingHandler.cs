using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMarkingHandler : MonoBehaviour, IMarkable
{
    public float Health {  get; private set; }
    public bool IsMark {  get; private set; }

    private void Start()
    {
        Health = transform.GetComponent<EnemyHealthComponent>().Health;
    }

    public void Mark()
    {
        IsMark = true;
    }

    public void Unmark()
    {
        IsMark = false;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Transform GetTransform()
    {
        return transform;
    }
    public void Die()
    {
        // TODO : �׾��� �� �ִϸ��̼� ���� ȿ�� �߰�
        // TODO : ����ġ ���� ���� �߰�
        gameObject.SetActive(false);
    }
}
