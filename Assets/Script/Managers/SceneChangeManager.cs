using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class SceneChangeManager : Singleton<SceneChangeManager>
{
    [SerializeField] private PlayableDirector pd;
    [SerializeField] private TimelineAsset[] ta;

    public void ChangeScene(string scene)
    {
        StartCoroutine(EndScene(scene));
    }

    private IEnumerator EndScene(string scene)
    {
        pd.Play(ta[1]);
        yield return new WaitForSeconds(1f);
        StartScene(scene);
    }

    private void StartScene(string scene)
    {
        SceneManager.LoadScene(scene);
        pd.Play(ta[0]);
    }
}
