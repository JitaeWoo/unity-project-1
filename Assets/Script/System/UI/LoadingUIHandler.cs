using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class LoadingUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private CanvasGroup _loadingUI;
    private float _loadingFadeDuration = 1f;

    private void Awake()
    {
        _loadingUI = GetComponent<CanvasGroup>();
        gameObject.SetActive(false);
    }

    public YieldInstruction StartLoading(string LoadingText = "·ÎµùÁß...")
    {
        _loadingUI.gameObject.SetActive(true);
        _text.text = LoadingText;
        return _loadingUI.DOFade(1f, _loadingFadeDuration).WaitForCompletion();
    }

    public YieldInstruction EndLoading()
    {
        YieldInstruction yieldInstruction = _loadingUI.DOFade(0f, _loadingFadeDuration).WaitForCompletion();
        StartCoroutine(EndLoadingUI());
        return yieldInstruction;
    }

    private IEnumerator EndLoadingUI()
    {
        yield return new WaitForSeconds(_loadingFadeDuration);
        _loadingUI.gameObject.SetActive(false);
    }
}
