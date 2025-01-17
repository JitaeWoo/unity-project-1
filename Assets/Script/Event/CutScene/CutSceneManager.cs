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

    private void Awake()
    {
        _pd = GetComponent<PlayableDirector>();
        _pd.played += _ => PlayerManager.Instance.Controller.SetIsControll(false);
        _pd.played += _ => _startCutScene.Invoke();
        _pd.stopped += _ => PlayerManager.Instance.Controller.SetIsControll(true);
        _pd.stopped += _ => _endCutScene.Invoke();

        // Player�� �ٷ�ٸ� Player ������Ʈ�� Ÿ�Ӷ��ο� ����
        foreach (PlayableBinding output in _pd.playableAsset.outputs)
        {
            if (output.streamName == "Player")
            {
                _pd.SetGenericBinding(output.sourceObject, PlayerManager.Instance.gameObject);
            }
        }
    }
}
