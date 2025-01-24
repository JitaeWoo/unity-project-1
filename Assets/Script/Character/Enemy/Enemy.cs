using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IMarkable
{
    public bool IsMark {  get; private set; }

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
}
