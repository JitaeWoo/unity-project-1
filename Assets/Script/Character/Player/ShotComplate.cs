using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotComplate : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Kill")){
            Destroy(enemy);
            Destroy(this.gameObject);
        }
    }
}
