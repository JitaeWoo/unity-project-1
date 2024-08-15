using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Zzz : MonoBehaviour
{
    string msg;
    int index;

    TextMeshProUGUI textMeshUGUI;

    void Start()
    {
        textMeshUGUI = GetComponent<TextMeshProUGUI>();
        msg = "Zzz..";
        index = 0;
        Zzzing();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Zzzing()
    {
        if(textMeshUGUI.text == "Zzz..")
        {
            textMeshUGUI.text = "";
            index = 0;
        }
        else
        {
            textMeshUGUI.text += msg[index];
            index++;
        }

        Invoke("Zzzing", 0.5f);
    }
}
