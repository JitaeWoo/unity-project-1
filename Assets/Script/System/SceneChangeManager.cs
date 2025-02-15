using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangeManager : Singleton<SceneChangeManager>
{
    public void ChangeScene(string scene, Action onSceneLoaded = null)
    {
        StartCoroutine(ChangeSceneRoutine(scene, onSceneLoaded));
    }

    private IEnumerator ChangeSceneRoutine(string scene, Action onSceneLoaded = null)
    {
        yield return UIManager.Instance.Loading.StartLoading();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                yield return new WaitForSeconds(1f);
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
        onSceneLoaded?.Invoke();

        yield return UIManager.Instance.Loading.EndLoading();
    }
}
