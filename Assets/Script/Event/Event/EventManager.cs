using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public Dictionary<string, EventNode> EventStates = new Dictionary<string, EventNode>();

    public EventNode GetOrCreateNode(string eventID)
    {
        if (!EventStates.ContainsKey(eventID))
        {
            EventStates[eventID] = new EventNode(eventID);
        }
        return EventStates[eventID];
    }

    public bool IsActivate(string eventID)
    {
        EventNode node = EventStates[eventID];

        return !node.IsCompleted && node.Prerequisites.All(prerequisite => prerequisite.IsCompleted);
    }

    public void AddDependency(string prerequisiteID, string dependentID)
    {
        EventNode dependent = EventStates[dependentID];
        EventNode prerequisite = GetOrCreateNode(prerequisiteID);

        dependent.Prerequisites.Add(prerequisite);
        prerequisite.Dependents.Add(dependent);
    }

    public void MarkEventComplete(string eventID)
    {
        if (EventStates.ContainsKey(eventID))
        {
            EventStates[eventID].Complete();
        }
    }
}
