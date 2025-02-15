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
        Debug.Log($"���� ���: {_savePath}");
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
        { // Vector3 ������ ��ȯ ���� ���� �߻��ؼ� ��ȯ ���� ���� ���� �߰�
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
            Debug.Log("����� ������ �����ϴ�.");
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

        yield return UIManager.Instance.Loading.StartLoading("������...");

        yield return new WaitForSeconds(1f);

        yield return UIManager.Instance.Loading.EndLoading();

        _blackScreenDown.DOAnchorPos(new Vector3(0, -1200, 0), 1f).SetEase(Ease.Linear);
        yield return _blackScreenUp.DOAnchorPos(new Vector3(0, 1200, 0), 1f).SetEase(Ease.Linear).WaitForCompletion();
        _blackScreenDown.gameObject.SetActive(false);
        _blackScreenUp.gameObject.SetActive(false);

        PlayerManager.Instance.StateManager.ChangeState(PlayerState.Alive);
    }
}
