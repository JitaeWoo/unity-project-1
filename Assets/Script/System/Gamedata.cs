using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string CurrentSceneName;
    public string CurrentRoomID;
    public Vector3 CurrentSavePointPosition;
    public Dictionary<string, EventNode> EventStates;
}
