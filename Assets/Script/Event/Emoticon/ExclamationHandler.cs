using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SoundPlayer))]
public class ExclamationHandler : MonoBehaviour
{
    [SerializeField] private AudioClip _exclamationAudio;
    private void OnEnable()
    {
        GetComponent<SoundPlayer>().PlaySound(_exclamationAudio);
        StartCoroutine(HideMark());
    }

    IEnumerator HideMark()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}

