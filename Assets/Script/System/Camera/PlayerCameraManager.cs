using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraManager : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.SetCameraConfiner(this.GetComponent<CinemachineConfiner>());
    }
}
