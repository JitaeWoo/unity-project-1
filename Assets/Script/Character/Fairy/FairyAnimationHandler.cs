using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyAnimationHandler : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void SetAnimationState(int state)
    {
        _animator.SetInteger("animationState", state);
    }
}
