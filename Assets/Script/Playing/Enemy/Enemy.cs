using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : DamageAble
{
    public float hp;
    [SerializeField] protected GameObject attack1;
    [SerializeField] protected GameObject attack2;
    [SerializeField] protected GameObject attack3;

    protected override void Awake()
    {
        base.Awake();
        this.gameObject.layer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
