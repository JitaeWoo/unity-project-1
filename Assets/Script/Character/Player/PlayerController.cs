using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
{
    private PlayerMovement _movement;
    private PlayerInputHandler _inputHandler;
    private bool isControll;

    void Update()
    {
        if (isControll)
        {
            Vector3 direction = PlayerManager.Instance.InputHandler.GetMovementInput();
            PlayerManager.Instance.Movement.Move(direction);
        }
    }

    public void SetIsControll(bool set)
    {
        isControll = set;
    }
}
