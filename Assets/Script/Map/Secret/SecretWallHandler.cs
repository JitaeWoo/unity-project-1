using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SecretWall : MonoBehaviour
{
    private TilemapRenderer _tilemapRenderer;
    private Material _material;
    private float _fadeDuration = 2f;

    private void Awake()
    {
        _tilemapRenderer = GetComponent<TilemapRenderer>();
    }

    private void Start()
    {
        _material = _tilemapRenderer.material;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _material.DOFade(0f, _fadeDuration);
        }
    }
}
