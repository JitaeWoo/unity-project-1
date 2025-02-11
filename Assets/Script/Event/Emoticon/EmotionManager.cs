using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionManager : MonoBehaviour
{
    private Dictionary<string, GameObject> _emotions = new Dictionary<string, GameObject>();
    private GameObject _currentEmotion;

    private void Awake()
    {
        foreach (Transform child in transform.Find("Emotions"))
        {
            Debug.Log($"{gameObject.name} : {child.name} set");
            _emotions[child.name] = child.gameObject;
            child.gameObject.SetActive(false);
        }
    }

    public void ShowEmotion(string emotionName)
    {
        Debug.Log($"{gameObject.name} : Show {emotionName}");
        if (!_emotions.ContainsKey(emotionName))
        {
            Debug.LogWarning($"[{gameObject.name}] '{emotionName}' 감정 표현이 존재하지 않습니다!");
            return;
        }

        if (_currentEmotion != null)
            _currentEmotion.SetActive(false);

        _currentEmotion = _emotions[emotionName];
        _currentEmotion.SetActive(true);
    }

    public void HideEmotion()
    {
        if (_currentEmotion != null)
        {
            _currentEmotion.SetActive(false);
            _currentEmotion = null;
        }
    }
}
