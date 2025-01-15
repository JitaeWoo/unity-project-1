using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventNode
{
    public string EventID;
    public HashSet<EventNode> Prerequisites = new HashSet<EventNode>();
    public HashSet<EventNode> Dependents = new HashSet<EventNode>();
    public bool IsCompleted;
    public bool IsInitialized;

    public EventNode(string eventID)
    {
        EventID = eventID;
        IsCompleted = false;
    }

    public void Complete()
    {
        if (IsCompleted) return;

        IsCompleted = true;

        foreach (var dependent in Dependents)
        {
            dependent.CheckAndActivate();
        }
    }

    public void CheckAndActivate()
    {
        if (IsCompleted) return;

        foreach (var prerequisite in Prerequisites)
        {
            if (!prerequisite.IsCompleted)
                return;
        }

        EventHandler[] events =  Object.FindObjectsOfType<EventHandler>();
        foreach (EventHandler e in events)
        {
            if (e.EventID == EventID)
            {
                e.SettingEvent();
            }
        }
    }

    // HashSet의 중복 검사를 위해 Equals와 GetHashCode 오버라이드
    public override bool Equals(object obj)
    {
        if (obj is EventNode otherNode)
        {
            return EventID == otherNode.EventID;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return EventID.GetHashCode();
    }
}
