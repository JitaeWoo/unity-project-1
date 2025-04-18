using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SoundPlayer))]
public class QuestionMarkHandler : MonoBehaviour
{
    [SerializeField] private AudioClip _questionAudio;
    private void OnEnable()
    {
        GetComponent<SoundPlayer>().PlaySound(_questionAudio);
        StartCoroutine(HideMark());
    }

    IEnumerator HideMark()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
