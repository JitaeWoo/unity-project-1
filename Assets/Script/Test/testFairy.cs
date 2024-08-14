using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testFairy : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("index", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
