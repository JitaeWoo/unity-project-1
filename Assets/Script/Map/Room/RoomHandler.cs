using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomHandler : MonoBehaviour
{
    public string RoomID;

    private void Awake()
    {
        RoomID = $"{SceneManager.GetActiveScene().name}_{this.gameObject.name}";
    }

    public void SetRoomActive(bool isActive)
    {
        transform.Find("Deactivatable").gameObject.SetActive(isActive);
    }

    public PolygonCollider2D GetCameraBoundary()
    {
        return transform.Find("CameraBoundary").GetComponent<PolygonCollider2D>();
    }
}
