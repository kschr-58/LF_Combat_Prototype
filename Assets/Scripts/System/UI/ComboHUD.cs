using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboHUD : MonoBehaviour
{
    [SerializeField] Animator _animator;
    
    public bool IsVisible {get; private set;}

    public void Show()
    {
        _animator.SetBool("Visible", true);

        IsVisible = true;
    }

    public void Hide()
    {
        _animator.SetBool("Visible", false);

        IsVisible = false;
    }
}
