using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventNode
{
    public string EventID;
    public HashSet<string> PrerequisiteIDs = new HashSet<string>();
    public HashSet<string> DependentIDs = new HashSet<string>();
    public bool IsCompleted;
    public bool IsInitialized;

    public EventNode() { }
    public EventNode(string eventID)
    {
        EventID = eventID;
        IsCompleted = false;
    }

    public void Complete()
    {
        if (IsCompleted) return;

        IsCompleted = true;

        foreach (var dependentID in DependentIDs)
        {
            EventManager.Instance.EventStates[dependentID].CheckAndActivate();
        }
    }

    public void CheckAndActivate()
    {
        if (IsCompleted) return;

        foreach (var prerequisiteID in PrerequisiteIDs)
        {
            if (!EventManager.Instance.EventStates[prerequisiteID].IsCompleted)
                return;
        }

        EventHandler[] events =  Object.FindObjectsOfType<EventHandler>();
        foreach (EventHandler e in events)
        {
            if (e.EventID == EventID)
            {
                e.SetEventActive(true);
            }
        }
    }
}
