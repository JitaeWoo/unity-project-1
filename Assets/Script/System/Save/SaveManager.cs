using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class SaveManager : Singleton<SaveManager>
{
    private string _savePath;

    private void Start()
    {
        _savePath = Path.Combine(Application.persistentDataPath, "save.json");
        Debug.Log($"저장 경로: {_savePath}");
    }

    public void SaveGameData(Vector3 currentPosition)
    {
        Debug.Log("Save Game Data!");
        GameData data = new GameData();

        data.CurrentSceneName = SceneManager.GetActiveScene().name;
        data.CurrentRoomID = RoomManager.Instance.CurrentRoom.RoomID;
        data.CurrentSavePointPosition = currentPosition;
        data.EventStates = EventManager.Instance.EventStates;

        string json = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
        { // Vector3 때문에 순환 참조 오류 발생해서 순환 참조 방지 설정 추가
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
        File.WriteAllText(_savePath, json);
    }

    public GameData LoadGameData()
    {
        if (File.Exists(_savePath))
        {
            Debug.Log("Load Game Data!");
            string json = File.ReadAllText(_savePath);
            GameData data = JsonConvert.DeserializeObject<GameData>(json);
            return data;
        }
        else
        {
            Debug.Log("저장된 파일이 없습니다.");
            return null;
        }
    }
}
