using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class AttackWarning : MonoBehaviour
{
    [SerializeField] private GameObject _attackPrefab;
    [SerializeField] private Vector2 _warningSize = new Vector2(3f, 3f); 
    [SerializeField] private float _warningDuration = 2f;
    private GameObject _fillWarning;

    private void Start()
    {
        
        StartWarning();
    }

    public void StartWarning()
    {
        transform.localScale = _warningSize;
        _fillWarning = Instantiate(transform.Find("Sprite").gameObject, transform); // 이미지만 복사 생성
        if (_fillWarning == null)
        {
            Debug.LogError("Sprite object not found!");
            return;
        }

        _fillWarning.transform.localScale = Vector3.zero;

        _fillWarning.transform.DOScale(Vector3.one, _warningDuration).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (_attackPrefab != null)
            {
                Instantiate(_attackPrefab, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        });
    }
}
