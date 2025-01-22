using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public PlayerHealth Health { get; private set; }
    public PlayerController Controller { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public PlayerMovement Movement { get; private set; }
    public PlayerStateManager StateManager { get; private set; }
    public PlayerStats Stats { get; private set; }
    public PlayerMarking Marking { get; private set; }



    private void Start()
    {
        Debug.Log("Player Start");

        Health = GetComponent<PlayerHealth>();
        Controller = GetComponent<PlayerController>();
        InputHandler = GetComponent<PlayerInputHandler>();
        Movement = GetComponent<PlayerMovement>();  
        StateManager = GetComponent<PlayerStateManager>();
        Stats = GetComponent<PlayerStats>();
        Marking = GetComponent<PlayerMarking>();
    }
}
