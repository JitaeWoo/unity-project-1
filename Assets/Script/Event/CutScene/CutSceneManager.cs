using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField] private UnityEvent _startCutScene;
    [SerializeField] private UnityEvent _endCutScene;
    private PlayableDirector _pd;

    private void Start()
    {
        _pd = GetComponent<PlayableDirector>();
        _pd.played += _ => _startCutScene.Invoke();
        _pd.stopped += _ => _endCutScene.Invoke();
    }
}
