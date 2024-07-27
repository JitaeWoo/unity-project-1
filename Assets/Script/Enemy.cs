using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : DamageAble
{
    public float hp;
    [SerializeField] GameObject attack1;
    [SerializeField] GameObject attack2;
    [SerializeField] GameObject attack3;

    void Awake(){
        this.gameObject.layer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
