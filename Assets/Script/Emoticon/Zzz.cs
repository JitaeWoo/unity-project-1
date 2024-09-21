using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Zzz : MonoBehaviour
{
    string msg;
    int index;

    TextMeshPro textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
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
        if(textMesh.text == "Zzz..")
        {
            textMesh.text = "";
            index = 0;
        }
        else
        {
            textMesh.text += msg[index];
            index++;
        }

        Invoke("Zzzing", 0.5f);
    }
}
