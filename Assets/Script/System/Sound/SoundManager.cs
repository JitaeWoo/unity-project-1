using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    private AudioSource _bgmSource;
    private Queue<AudioSource> _sfxSourcePool = new Queue<AudioSource>();
    private int _poolSize = 30;
    private void Awake()
    {
        _bgmSource = gameObject.AddComponent<AudioSource>();
        _bgmSource.loop = true;

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject obj = new GameObject("SFX_AudioSource");
            obj.transform.SetParent(transform);
            AudioSource source = obj.AddComponent<AudioSource>();
            _sfxSourcePool.Enqueue(source);
        }
    }

    public void PlayBGM(AudioClip clip)
    {
        if (_bgmSource.clip == clip) return;

        _bgmSource.Stop();
        _bgmSource.clip = clip;
        _bgmSource.Play();
    }

    public void PlaySFX(AudioClip clip, Vector3 position, float volume = 1f)
    {
        if (_sfxSourcePool.Count == 0) return;

        AudioSource source = _sfxSourcePool.Dequeue();
        source.transform.position = position;
        source.PlayOneShot(clip, volume);
        StartCoroutine(ReturnToPool(source, clip.length));
    }

    private IEnumerator ReturnToPool(AudioSource source, float delay)
    {
        yield return new WaitForSeconds(delay);
        _sfxSourcePool.Enqueue(source);
    }
}
