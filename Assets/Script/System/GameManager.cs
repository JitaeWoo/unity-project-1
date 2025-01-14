using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject _playerPrefeb;
    private CinemachineConfiner _playerCameraConfiner;
    private GameObject _player;

    public void MoveToRoom(GameObject nextRoom, Vector2 direction)
    {
        if (nextRoom != null)
        {
            // 비활성화된 요소를 활성화한다.
            nextRoom.transform.Find("Deactivatable").gameObject.SetActive(true);

            Vector3 newPosition = PlayerController.Instance.transform.position + (Vector3)direction;
            PlayerController.Instance.transform.position = newPosition;

            // 카메라 confiner 범위 변경
            _playerCameraConfiner.m_BoundingShape2D = nextRoom.transform.Find("CameraBoundary").GetComponent<PolygonCollider2D>();
        }
        else
        {
            Debug.LogError("Next room is not assigned!");
        }
    }

    public void SetCameraConfiner(CinemachineConfiner confiner)
    {
        _playerCameraConfiner = confiner;
    }

    public void StartGame()
    {
        _player = Instantiate(_playerPrefeb);
        GameData gameData = SaveManager.Instance.LoadGameData();
        if (gameData != null)
        {
            EventManager.Instance.EventStates = gameData.EventStates;
            _player.transform.position = gameData.CurrentSavePointPosition;
            SceneChangeManager.Instance.ChangeScene(gameData.CurrentSceneName);
        }
        else // 게임 첫 시작 시
        {
            _player.transform.position = new Vector3(0, 1, 0);
            SceneChangeManager.Instance.ChangeScene("Cave");
        }
        
    }
}
