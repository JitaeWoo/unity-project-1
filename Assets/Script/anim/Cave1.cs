using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Cave1 : MonoBehaviour
{
    [SerializeField] private PlayableDirector pd;
    [SerializeField] private TimelineAsset ta;
    void Start()
    {
        StartCoroutine("ExitTimeline");
    }

    IEnumerator ExitTimeline()
    {
        pd.Play(ta);
        yield return new WaitForSeconds(9f);
        GameObject.FindWithTag("Player").GetComponent<Animator>().enabled = false;
    }
}
