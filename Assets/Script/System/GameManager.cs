using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject _playerPrefeb;
    private GameObject _player;

    public void StartGame()
    {
        _player = Instantiate(_playerPrefeb);
        GameData gameData = SaveManager.Instance.LoadGameData();
        if (gameData != null)
        {
            EventManager.Instance.EventStates = gameData.EventStates;
            _player.transform.position = gameData.CurrentSavePointPosition;
            SceneChangeManager.Instance.ChangeScene(gameData.CurrentSceneName, () =>
            {
                // 씬 로드 후 실행될 코드
                RoomHandler room = RoomManager.Instance.FindRoom(gameData.CurrentRoomID);
                RoomManager.Instance.RoomActivate(room);
            });
        }
        else // 게임 첫 시작 시
        {
            _player.transform.position = new Vector3(0, 1, 0);
            SceneChangeManager.Instance.ChangeScene("Cave", () =>
            {
                // 씬 로드 후 실행될 코드
                RoomHandler room = RoomManager.Instance.FindRoom("Cave_Room_1");
                RoomManager.Instance.RoomActivate(room);
            });
        }
        
    }
}
