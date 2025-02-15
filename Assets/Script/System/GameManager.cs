using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject _playerPrefeb;
    private GameObject _player;
    public GameData LastSavedData;

    private void Start()
    {
        _player = Instantiate(_playerPrefeb);
    }

    public void StartGame()
    {
        LastSavedData = SaveManager.Instance.LoadGameData();
        if (LastSavedData != null)
        {
            EventManager.Instance.EventStates = EventManager.Instance.CopyEventStates(LastSavedData.EventStates);

            SceneChange(LastSavedData.CurrentSceneName
                , LastSavedData.CurrentRoomID,
                LastSavedData.CurrentSavePointPosition);
        }
        else // 게임 첫 시작 시
        {
            SceneChange("Cave", "Cave_Room_1", new Vector3(0, 1, 0));
        }
    }

    public void GameOver()
    {
        if(LastSavedData != null)
        {
            SceneChange(LastSavedData.CurrentSceneName
                , LastSavedData.CurrentRoomID
                , LastSavedData.CurrentSavePointPosition
                , () =>
                {
                    // 씬 로드 후 실행될 코드
                    PlayerManager.Instance.Health.ResetHealth();
                    PlayerManager.Instance.StateManager.ChangeState(PlayerState.Alive);
                });
        }
        else
        {
            GoMainMenu();
        }
    }

    private void GoMainMenu()
    {
        SceneChangeManager.Instance.ChangeScene("MainMenu", () =>
        {
            // 씬 로드 후 실행될 코드
            Destroy(_player);
            UIManager.Instance.GamePlay.gameObject.SetActive(false);
        });
    }

    public void SceneChange(string sceneName, string roomID, Vector3 playerPosition, Action onSceneLoaded = null)
    {
        PlayerManager.Instance.StateManager.ChangeState(PlayerState.Loading);
        SceneChangeManager.Instance.ChangeScene(sceneName, () =>
        {
            // 씬 로드 후 실행될 코드
            RoomHandler room = RoomManager.Instance.FindRoom(roomID);
            RoomManager.Instance.RoomActivate(room);

            _player.transform.position = playerPosition;

            if(PlayerManager.Instance.StateManager.CurrentState == PlayerState.Loading)
            {
                PlayerManager.Instance.StateManager.ChangeState(PlayerState.Alive);
            }
            
            onSceneLoaded?.Invoke();
        });
    }
}
