using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject shot;
    private GameObject curShot;
    // Start is called before the first frame update
    void Start()
    {
        curShot = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, transform.forward, 1f, LayerMask.GetMask("Enemy"));
            if(hit.collider != null)
            {
                Debug.Log("I layer!!");
                if(GameObject.FindWithTag("Shot") != null){

                }else{
                    curShot = Instantiate(shot, hit.transform.position, Quaternion.identity);
                    curShot.GetComponent<ShotManager>().enemy = hit.transform.gameObject;
                    curShot.GetComponent<ShotManager>().playerDamage = GameObject.FindWithTag("Player").GetComponent<PlayerController>().damage;
                }
            }
        }
    }
}
