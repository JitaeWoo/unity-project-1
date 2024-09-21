using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueStep : MonoBehaviour
{
    [SerializeField]
    private List<string> DialogueTextList = new List<string>();
    [SerializeField]
    private GameObject chatBoxPoint;

    private bool isActive;
    public void Active(Vector3 position)
    {
        isActive = true;
    }

    private void DeActive()
    {
       isActive = false;
    }
}
