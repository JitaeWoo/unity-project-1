using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler
{
    public Vector3 GetMovementInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        return new Vector3(x, y, 0).normalized;
    }
}
