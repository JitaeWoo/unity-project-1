using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Playables;
using UnityEngine.Events;

public class EventHandler : MonoBehaviour
{
    [SerializeField] public string EventID;
    [SerializeField] private EventHandler[] _prerequisiteEvents;
    [SerializeField] private UnityEvent _startEvent;
    [SerializeField] private UnityEvent _settingEvent;

    private void Awake()
    {
        EventNode node = EventManager.Instance.GetOrCreateNode(EventID);
        if (node.IsInitialized)
        {
            return;
        }
        node.IsInitialized = true;

        foreach(EventHandler prerequisite in _prerequisiteEvents)
        {
            EventManager.Instance.AddDependency(prerequisite.EventID, EventID);
        }
    }

    private void Start()
    {
        if (EventManager.Instance.IsActivate(EventID))
        {
            SettingEvent();
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public void StartEvent()
    {
        EventManager.Instance.MarkEventComplete(EventID);
        this.gameObject.SetActive(false);
        _startEvent.Invoke();
    }

    public void SettingEvent()
    {
        this.gameObject.SetActive(true);
        _settingEvent.Invoke();
    }
}
