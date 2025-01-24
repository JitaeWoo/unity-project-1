using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMarkable
{
    public bool IsMark { get; }
    public void Mark();
    public void Unmark();
    public Vector3 GetPosition();
    public Transform GetTransform();
}
