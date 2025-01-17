using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SpeechBubbleManager : MonoBehaviour
{
    [SerializeField] private string[] _dialogs;
    [SerializeField] private UnityEvent _onStarted;
    [SerializeField] private UnityEvent _onEnded;
    private SpriteRenderer _sprite;
    private TextMeshPro _text;
    private int _currentDialogIndex;
    private bool _isPlay = false;

    void Update()
    {
        if (_isPlay && Input.GetButtonDown("interact"))
        {
            PlayDialog();
        }
    }

    private void PlayDialog()
    {
        if (_currentDialogIndex < _dialogs.Length)
        {
            _text.text = _dialogs[_currentDialogIndex];
            FitSprite();
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            _isPlay = false;

            PlayerManager.Instance.Controller.SetIsControll(true);
            if (_onEnded != null)
            {
                _onEnded.Invoke();
            }
        }

        _currentDialogIndex++;
    }

    // �ؽ�Ʈ�� �°� ��ǳ�� �̹����� �ؽ�Ʈ �ڽ� ũ�� ����
    private void FitSprite()
    {
        // ���� ������ �ʺ� 10�� ���߱� ���� �ؽ�Ʈ �ڽ� �ʱ�ȭ ����
        _text.rectTransform.sizeDelta = new Vector2(10, 2);

        float x = _text.preferredWidth;
        float y = _text.preferredHeight;
        x = x > 10 ? 10 : x;

        _sprite.size = new Vector2(x + 0.3f, y + 0.3f);
        _text.rectTransform.sizeDelta = new Vector2(x, y);
    }

    public void StartDialog()
    {
        if (_onStarted != null)
        {
            _onStarted.Invoke();
        }
        PlayerManager.Instance.Controller.SetIsControll(false);

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _text = GetComponentInChildren<TextMeshPro>();
        _currentDialogIndex = 0;
        _isPlay = true;

        PlayDialog();
    }
}
