using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject _playerPrefeb;
    [SerializeField] private GameObject _gamePlayUIPrefeb;
    private GameObject _player;
    private GameObject _gamePlayUI;
    private GameData _lastSavedData;

    public void StartGame()
    {
        _gamePlayUI = Instantiate(_gamePlayUIPrefeb);
        _gamePlayUI.SetActive(false);
        _player = Instantiate(_playerPrefeb);

        _lastSavedData = SaveManager.Instance.LoadGameData();
        if (_lastSavedData != null)
        {
            EventManager.Instance.EventStates = _lastSavedData.EventStates;

            SceneChange(_lastSavedData.CurrentSceneName
                , _lastSavedData.CurrentRoomID,
                _lastSavedData.CurrentSavePointPosition);
        }
        else // 게임 첫 시작 시
        {
            SceneChange("Cave", "Cave_Room_1", new Vector3(0, 1, 0));
        }
    }

    public void GameOver()
    {
        if(_lastSavedData != null)
        {
            SceneChange(_lastSavedData.CurrentSceneName
                , _lastSavedData.CurrentRoomID
                , _lastSavedData.CurrentSavePointPosition
                , () =>
                {
                    PlayerManager.Instance.GetComponent<PlayerHealth>().ResetHealth();
                    PlayerManager.Instance.Controller.SetIsControll(true);
                });
        }
        else
        {
            GoMainMenu();
        }
    }

    private void GoMainMenu()
    {
        Destroy(_player);
        Destroy(_gamePlayUI);
        SceneChangeManager.Instance.ChangeScene("MainMenu");
    }

    public void SceneChange(string sceneName, string roomID, Vector3 playerPosition, Action onSceneLoaded = null)
    {
        SceneChangeManager.Instance.ChangeScene(sceneName, () =>
        {
            // 씬 로드 후 실행될 코드
            RoomHandler room = RoomManager.Instance.FindRoom(roomID);
            RoomManager.Instance.RoomActivate(room);

            _player.transform.position = playerPosition;
            _gamePlayUI.SetActive(true);

            onSceneLoaded?.Invoke();
        });
    }
}
