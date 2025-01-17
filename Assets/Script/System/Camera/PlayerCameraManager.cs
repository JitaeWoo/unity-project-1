using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraManager : Singleton<PlayerCameraManager>
{
    private CinemachineVirtualCamera _playerCamera;

    private void Awake()
    {
        _playerCamera = GetComponent<CinemachineVirtualCamera>();
        _playerCamera.Follow = PlayerManager.Instance.transform;
    }

    public void SetCameraBoundary(PolygonCollider2D Boundary)
    {
        this.GetComponent<CinemachineConfiner>().m_BoundingShape2D = Boundary;
    }
}
