using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave2ExitBottom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneChangeManager.Instance.ChangeScene("Cave1");
        }
    }
}
