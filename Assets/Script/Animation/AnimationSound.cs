using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Animation Event를 통해 Sound를 재생하기 위한 코드
[RequireComponent(typeof(SoundPlayer))]
public class AnimationSoundEvent : MonoBehaviour
{
    public void SoundPlay(AudioClip clip)
    {
        GetComponent<SoundPlayer>().PlaySound(clip);
    }
}
