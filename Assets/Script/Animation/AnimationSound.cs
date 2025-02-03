using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Animation Event�� ���� Sound�� ����ϱ� ���� �ڵ�
[RequireComponent(typeof(SoundPlayer))]
public class AnimationSoundEvent : MonoBehaviour
{
    public void SoundPlay(AudioClip clip)
    {
        GetComponent<SoundPlayer>().PlaySound(clip);
    }
}
