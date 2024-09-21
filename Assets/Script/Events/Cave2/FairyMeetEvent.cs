using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class FairyMeetEvent : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Fairy;
    [SerializeField] private GameObject Qus_Exc;
    [SerializeField] private GameObject Zzz;
    [SerializeField] private GameObject Wall;
    [SerializeField] private GameObject Button;
    [SerializeField] private GameObject Camera1;
    [SerializeField] private GameObject Camera2;
    private Color color;
    private SpriteRenderer rd;
    private TextMeshProUGUI tmp;
    private bool isEntered;
    private bool isShowButton;
    private bool isInteract;

    private void Awake()
    {
        rd = Button.GetComponent<SpriteRenderer>();
        tmp = Button.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (isEntered & !isInteract)
        {
            if (Input.GetButtonDown("interact"))
            {
                isInteract = true;
                Button.SetActive(false);
                Camera1.SetActive(false);
                Camera2.SetActive(true);
                PlayerController.Instance.SetIsControll(false);
                StartCoroutine(AwakingFairy()); // 애니메이션 1번 재생
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isEntered = true;
        if (collision.gameObject.CompareTag("Player") && !isShowButton)
        {
            StartCoroutine("ShowButton");
            isShowButton = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isEntered = false;
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

    // 애니메이션 1번
    private IEnumerator AwakingFairy()
    {
        Zzz.SetActive(false);
        yield return new WaitForSeconds(2f);
        Qus_Exc.SetActive(true);
        yield return new WaitForSeconds(2f);
        Fairy.GetComponent<Animator>().SetInteger("index", 0);
        yield return new WaitForSeconds(2f);
        Qus_Exc.GetComponent<TextMeshPro>().text = "!";
        Qus_Exc.SetActive(true);

        // akf


    }
}

