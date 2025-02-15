using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using DG.Tweening;

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField] private RectTransform _blackScreenUp;
    [SerializeField] private RectTransform _blackScreenDown;
    private string _savePath;

    private void Start()
    {
        _savePath = Path.Combine(Application.persistentDataPath, "save.json");
        Debug.Log($"저장 경로: {_savePath}");
    }

    public void SaveGameData(Vector3 currentPosition)
    {
        StartCoroutine(StartSaveCutScene());

        Debug.Log("Save Game Data!");
        GameData data = new GameData();

        data.CurrentSceneName = SceneManager.GetActiveScene().name;
        data.CurrentRoomID = RoomManager.Instance.CurrentRoom.RoomID;
        data.CurrentSavePointPosition = currentPosition;
        data.EventStates = EventManager.Instance.CopyEventStates(EventManager.Instance.EventStates);

        GameManager.Instance.LastSavedData = data;

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

    IEnumerator StartSaveCutScene()
    {
        PlayerManager.Instance.StateManager.ChangeState(PlayerState.Cutscene);

        _blackScreenDown.gameObject.SetActive(true);
        _blackScreenUp.gameObject.SetActive(true);
        _blackScreenDown.DOAnchorPos(new Vector3(0, -400, 0), 1f).SetEase(Ease.Linear);
        yield return _blackScreenUp.DOAnchorPos(new Vector3(0, 400, 0), 1f).SetEase(Ease.Linear).WaitForCompletion();

        yield return UIManager.Instance.Loading.StartLoading("저장중...");

        yield return new WaitForSeconds(1f);

        yield return UIManager.Instance.Loading.EndLoading();

        _blackScreenDown.DOAnchorPos(new Vector3(0, -1200, 0), 1f).SetEase(Ease.Linear);
        yield return _blackScreenUp.DOAnchorPos(new Vector3(0, 1200, 0), 1f).SetEase(Ease.Linear).WaitForCompletion();
        _blackScreenDown.gameObject.SetActive(false);
        _blackScreenUp.gameObject.SetActive(false);

        PlayerManager.Instance.StateManager.ChangeState(PlayerState.Alive);
    }
}
