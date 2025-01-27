using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWarning
{
    public void SetWarningDuration(float warningDuration);

    public void SetWarningSize(Vector2 warningSize);

    public void StartWarning();
}
