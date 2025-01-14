using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public Dictionary<string, bool> EventStates = new Dictionary<string, bool>();

    public void MarkEventComplete(string eventID)
    {
        EventStates[eventID] = true;
    }

    public bool IsEventComplete(string eventID)
    {
        return EventStates.ContainsKey(eventID) && EventStates[eventID];
    }
}
