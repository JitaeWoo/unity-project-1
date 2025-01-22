using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChange : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private string _roomID;
    [SerializeField] private Vector2 _playerPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SceneChange(_sceneName, _roomID, _playerPosition);
        }
    }
}
