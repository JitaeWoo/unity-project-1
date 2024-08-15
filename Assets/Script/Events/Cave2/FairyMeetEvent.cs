using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class FairyMeetEvent : MonoBehaviour
{
    [SerializeField] private GameObject Wall;
    [SerializeField] private GameObject Button;
    [SerializeField] private GameObject CutPlay;
    private PlayableDirector pd;
    private Color color;
    private SpriteRenderer rd;
    private TextMeshProUGUI tmp;
    private bool isEntered;

    private void Awake()
    {
        rd = Button.GetComponent<SpriteRenderer>();
        tmp = Button.GetComponentInChildren<TextMeshProUGUI>();
        pd = CutPlay.GetComponent<PlayableDirector>();
        isEntered = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButtonDown("interact"))
        {
            //pd.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isEntered)
        {
            StartCoroutine("ShowButton");
            isEntered = true;
        }
    }

    IEnumerator ShowButton()
    {
        color = rd.color;
        float a = 0f;

        while (a < 1f)
        {
            a += 1f * Time.deltaTime;
            color.a = a;
            rd.color = color;
            tmp.color = color; 
            yield return null;
        }
    }
}

