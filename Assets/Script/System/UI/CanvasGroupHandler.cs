using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGroupHandler : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 2f;
    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void FadeIn()
    {
        _canvasGroup.DOFade(1f, fadeDuration);
    }

    public void FadeOut()
    {
        _canvasGroup.DOFade(0f, fadeDuration);
    }
}
