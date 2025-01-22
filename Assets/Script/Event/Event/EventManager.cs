using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.UI.Image;

public class EventManager : Singleton<EventManager>
{
    public Dictionary<string, EventNode> EventStates = new Dictionary<string, EventNode>();
    public Dictionary<string, EventNode> PlayerMemory = new Dictionary<string, EventNode>();

    public EventNode GetOrCreateNode(string eventID)
    {
        if (!EventStates.ContainsKey(eventID))
        {
            EventStates[eventID] = new EventNode(eventID);
        }
        if(!PlayerMemory.ContainsKey(eventID))
        {
            PlayerMemory[eventID] = new EventNode(eventID);
        }

        return EventStates[eventID];
    }

    public bool IsActivate(string eventID)
    {
        EventNode node = EventStates[eventID];

        return !node.IsCompleted && node.PrerequisiteIDs.All(ID => EventStates[ID].IsCompleted);
    }

    public bool IsPlayerExperienced(string eventID)
    {
        if (PlayerMemory.ContainsKey(eventID))
        {
            EventNode node = PlayerMemory[eventID];

            return node.IsCompleted;
        }
        else
        {
            return false;
        }
        
    }

    public void AddDependency(string prerequisiteID, string dependentID)
    {
        EventNode dependent = EventStates[dependentID];
        EventNode prerequisite = GetOrCreateNode(prerequisiteID);

        dependent.PrerequisiteIDs.Add(prerequisiteID);
        prerequisite.DependentIDs.Add(dependentID);
    }

    public void MarkEventComplete(string eventID)
    {
        if (EventStates.ContainsKey(eventID))
        {
            EventStates[eventID].Complete();
            PlayerMemory[eventID].Complete();
        }
    }

    public void RollbackEvent()
    {
        EventStates = CopyEventStates(GameManager.Instance.LastSavedData.EventStates);

        foreach (var pair in GameManager.Instance.LastSavedData.EventStates)
        {
            Debug.Log("lasted");
            Debug.Log(pair.Value.EventID);
            Debug.Log(pair.Value.IsCompleted);
        }
    }

    public Dictionary<string, EventNode> CopyEventStates(Dictionary<string, EventNode> original)
    {
        Dictionary<string, EventNode>  EventStates = new Dictionary<string, EventNode>();

        foreach (var pair in original)
        {
            EventStates.Add(pair.Key, new EventNode
            {
                EventID = pair.Value.EventID,
                PrerequisiteIDs = new HashSet<string>(pair.Value.PrerequisiteIDs),
                DependentIDs = new HashSet<string>(pair.Value.DependentIDs),
                IsCompleted = pair.Value.IsCompleted,
                IsInitialized = pair.Value.IsInitialized
            });
        }

        return EventStates;
    }
}
