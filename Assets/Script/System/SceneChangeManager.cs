using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangeManager : Singleton<SceneChangeManager>
{
    [SerializeField] private float _fadeDuration = 1f;
    [SerializeField] private CanvasGroup _loadingCanvas;

    public void ChangeScene(string scene)
    {
        StartCoroutine(ChangeSceneRoutine(scene));
    }

    private IEnumerator ChangeSceneRoutine(string scene)
    {
        _loadingCanvas.gameObject.SetActive(true);
        yield return _loadingCanvas.DOFade(1f, _fadeDuration).WaitForCompletion();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;

            }
            yield return null;
        }
        yield return new WaitForSeconds(1f);

        yield return _loadingCanvas.DOFade(0f, _fadeDuration).WaitForCompletion();
        _loadingCanvas.gameObject.SetActive(false);
    }
}
