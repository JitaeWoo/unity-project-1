using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy1 : Enemy
{
    void Start(){
        hp = 10f;
        damage = 10f;
        StartCoroutine(Attack1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Attack1()
    {
        while(true){
            Instantiate(attack1, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(1f);
        }
    }
}
