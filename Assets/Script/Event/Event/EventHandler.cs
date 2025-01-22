using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Playables;
using UnityEngine.Events;

public class EventHandler : MonoBehaviour
{
    [SerializeField] public string EventID;
    [SerializeField] private string[] _prerequisiteEventIDs;
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
        Debug.Log($"{gameObject.name} is initializing");

        foreach(string prerequisiteID in _prerequisiteEventIDs)
        {
            EventManager.Instance.AddDependency(prerequisiteID, EventID);
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
            SetEventActive(false);
        }
    }

    public void StartEvent()
    {
        EventManager.Instance.MarkEventComplete(EventID);
        this.gameObject.SetActive(false);
        _startEvent.Invoke();
    }

    private void SettingEvent()
    {
        Debug.Log($"{gameObject.name} is setting");
        _settingEvent.Invoke();
    }

    public void SetEventActive(bool active)
    {
        Debug.Log($"{gameObject.name} is setting active {active}");
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(active);
        }
    }
}
