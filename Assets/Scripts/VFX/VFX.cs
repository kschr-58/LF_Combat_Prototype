using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{
    [SerializeField] string animBool;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        _animator.SetBool(animBool, true);
    }

    public void Exit()
    {
        _animator.SetBool(animBool, false);

        Destroy(gameObject);
    }
}
