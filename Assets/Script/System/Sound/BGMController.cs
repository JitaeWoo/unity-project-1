using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMController : MonoBehaviour
{
    [System.Serializable]
    private class SceneBGM
    {
        public string SceneName;
        public AudioClip Clip;
    }

    [SerializeField] private List<SceneBGM> _bgmList;
    private Dictionary<string, AudioClip> _bgmMap = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        foreach (SceneBGM item in _bgmList)
        {
            if (!_bgmMap.ContainsKey(item.SceneName))
            {
                _bgmMap.Add(item.SceneName, item.Clip);
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (_bgmMap.ContainsKey(scene.name))
        {
            SoundManager.Instance.PlayBGM(_bgmMap[scene.name]);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
