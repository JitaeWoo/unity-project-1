using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Singleton<PlayerController>
{
    private PlayerMovement _movement;
    private PlayerInputHandler _inputHandler;
    private bool isControll;

    void Start()
    {
        Debug.Log("Player Start");
        
        _movement = GetComponent<PlayerMovement>();
        _inputHandler = new PlayerInputHandler();
        isControll = true;
    }

    void Update()
    {
        if (isControll)
        {
            Vector3 direction = _inputHandler.GetMovementInput();
            _movement.Move(direction);
        }
    }

    public void SetIsControll(bool set)
    {
        isControll = set;
    }
}
