using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public void PlaySound(AudioClip clip, float volume = 1f)
    {
        if (clip == null) return;
        SoundManager.Instance.PlaySFX(clip, transform.position, volume);
    }
}
