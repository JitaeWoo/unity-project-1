using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public PlayerHealth Health { get; private set; }
    public PlayerController Controller { get; private set; }
    public PlayerDamageHandler DamageHandler { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public PlayerMovement Movement { get; private set; }
    public PlayerInvincibilityManager InvincibilityManager { get; private set; }

    private void Start()
    {
        Debug.Log("Player Start");

        Health = GetComponent<PlayerHealth>();
        Controller = GetComponent<PlayerController>();
        DamageHandler = GetComponent<PlayerDamageHandler>();
        InputHandler = GetComponent<PlayerInputHandler>();
        Movement = GetComponent<PlayerMovement>();
    }
}
