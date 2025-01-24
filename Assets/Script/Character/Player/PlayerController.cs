using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
    private bool isControl = true;

    void Update()
    {
        if (isControl)
        {
            Vector3 direction = PlayerManager.Instance.InputHandler.GetMovementInput();
            PlayerManager.Instance.Movement.Move(direction);

            IMarkable markable = PlayerManager.Instance.InputHandler.GetMarkable();
            if (markable != null)
            {
                PlayerManager.Instance.Marking.TryMark(markable);
            }
        }
    }

    public void SetIsControll(bool set)
    {
        isControl = set;
    }
}
