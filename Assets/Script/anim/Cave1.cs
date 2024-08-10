using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Cave1 : MonoBehaviour
{
    PlayableDirector pd;
    void Start()
    {
        Debug.Log("feiadf");
        pd = GetComponent<PlayableDirector>();
        StartCoroutine("ExitTimeline");
        Debug.Log("dfes");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ExitTimeline()
    {
        Debug.Log("dfa");
        yield return new WaitForSeconds(9f);
        GameObject.FindWithTag("Player").GetComponent<Animator>().enabled = false;
        Debug.Log("dfasefdsfaaefa");
    }
}
