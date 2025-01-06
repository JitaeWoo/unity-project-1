using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : Singleton<GameManager>
{
    private CinemachineConfiner _playerCameraConfiner;
    private PlayerController _player;
    public GameObject shot;
    private GameObject curShot;

    void Start()
    {
        curShot = null;
    }

    void Update()
    {
        /*if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, transform.forward, 1f, LayerMask.GetMask("Enemy"));
            if(hit.collider != null)
            {
                Debug.Log("I layer!!");
                if(GameObject.FindWithTag("Shot") != null){

                }else{
                    curShot = Instantiate(shot, hit.transform.position, Quaternion.identity);
                    curShot.GetComponent<Shot>().enemy = hit.transform.gameObject;
                    curShot.GetComponent<Shot>().playerDamage = GameObject.FindWithTag("Player").GetComponent<PlayerController>().damage;
                }
            }
        }*/
    }

    public void MoveToRoom(GameObject nextRoom, Vector2 direction)
    {
        if (nextRoom != null)
        {
            // 비활성화된 요소를 활성화한다.
            nextRoom.transform.Find("Deactivatable").gameObject.SetActive(true);

            Vector3 newPosition = PlayerController.Instance.transform.position + (Vector3)direction;
            PlayerController.Instance.transform.position = newPosition;

            // 카메라 confiner 범위 변경
            _playerCameraConfiner.m_BoundingShape2D = nextRoom.transform.Find("CameraBoundary").GetComponent<PolygonCollider2D>();
        }
        else
        {
            Debug.LogError("Next room is not assigned!");
        }
    }

    public void SetCameraConfiner(CinemachineConfiner confiner)
    {
        _playerCameraConfiner = confiner;
    }
}
