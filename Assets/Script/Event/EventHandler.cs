using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Playables;
using UnityEngine.Events;

public class EventHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _startEvent;
    [SerializeField] private UnityEvent _settingEvent;
    [SerializeField] private string _eventID;

    private void Start()
    {
        bool isCompleted = EventManager.Instance.IsEventComplete(_eventID);

        if (isCompleted )
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            SettingEvent();
        }
        
    }

    public void StartEvent()
    {
        EventManager.Instance.MarkEventComplete(_eventID);
        this.gameObject.SetActive(false);
        _startEvent.Invoke();
    }

    public void SettingEvent()
    {
        _settingEvent.Invoke();
    }
}
