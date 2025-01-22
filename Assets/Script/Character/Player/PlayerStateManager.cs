using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public enum PlayerState
{
    Alive,
    Dead,
    Cutscene,
    Invincible
}
public class PlayerStateManager : MonoBehaviour
{
    public PlayerState CurrentState { get; private set; } = PlayerState.Alive;
    private float _invincibleDuration = 0.5f;

    public void ChangeState(PlayerState newState)
    {
        if (CurrentState == newState) return;

        CurrentState = newState;
        Debug.Log($"ChangePlayerState : {CurrentState}");
        HandleStateChange(newState);
    }

    private void HandleStateChange(PlayerState newState)
    {
        switch (newState)
        {
            case PlayerState.Alive:
                PlayerManager.Instance.Controller.SetIsControll(true);
                break;

            case PlayerState.Dead:
                PlayerManager.Instance.Controller.SetIsControll(false);
                EventManager.Instance.RollbackEvent();
                GameManager.Instance.GameOver();
                break;

            case PlayerState.Cutscene:
                PlayerManager.Instance.Controller.SetIsControll(false);
                break;

            case PlayerState.Invincible:
                break;
        }
    }

    private IEnumerator InvincibilityCoroutine()
    {
        yield return new WaitForSeconds(_invincibleDuration);
        CurrentState = PlayerState.Alive;
    }
}
