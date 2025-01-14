using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointHandler : MonoBehaviour
{
    public void SaveGame()
    {
        Debug.Log("Save Game!");
        SaveManager.Instance.SaveGameData(transform.position);
    }
}
