using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField] 
    private GameObject chatBox;
    private GameObject currentChatBox;
    private TextMeshProUGUI currentText;

    private bool isActive;

    [SerializeField]
    private Vector3 text;




    private void Awake()
    {
        
    }

    private void Active(Vector3 position, DialogueStep firstDialogue)
    {
        isActive = true;
        currentChatBox = Instantiate(chatBox, Camera.main.WorldToScreenPoint(position), Quaternion.identity);
        currentText = currentChatBox.GetComponentInChildren<TextMeshProUGUI>();
        firstDialogue.Active(position);

    }

    private void DeActive()
    {
        isActive = false;
    }

    public void SetText(string text)
    {
    }
}
