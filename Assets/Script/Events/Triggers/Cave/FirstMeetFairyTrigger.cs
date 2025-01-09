using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FirstMeetFairyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _interactiveKeyAwake;
    private CanvasGroup _canvasGroup;
    private float _fadeDuration = 1.0f;
    private bool _isActive = false;

    private void Start()
    {
        _canvasGroup = _interactiveKeyAwake.GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (_isActive)
        {
            if (Input.GetButton("interact"))
            {
                _interactiveKeyAwake.SetActive(false);
                this.gameObject.SetActive(false);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _canvasGroup.DOFade(1f, _fadeDuration);
            _isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _canvasGroup.DOFade(0f, _fadeDuration);
            _isActive = false;
        }
    }
}
