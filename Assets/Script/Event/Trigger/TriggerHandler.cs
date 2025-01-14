using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TriggerHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _enterTrigger;
    [SerializeField] private UnityEvent _exitTrigger;
    [SerializeField] private UnityEvent _playerInteract;
    private bool _isActive = false;

    private void Update()
    {
        if(_isActive && Input.GetButtonDown("interact"))
        {
            _playerInteract.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isActive = true;
            _enterTrigger.Invoke();
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _isActive = false;
        _exitTrigger.Invoke();
    }
}
