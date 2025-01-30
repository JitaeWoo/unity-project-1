using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [Header("����� �ҽ�")]
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("����� Ŭ��")]
    public AudioClip bgmClip;
    public AudioClip attackClip;
    public AudioClip hitClip;

    public void PlayBGM()
    {
        if (!bgmSource.isPlaying)
        {
            bgmSource.clip = bgmClip;
            bgmSource.loop = true;
            bgmSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
