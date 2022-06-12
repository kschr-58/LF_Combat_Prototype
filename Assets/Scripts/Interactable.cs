using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable: MonoBehaviour
{
    [SerializeField] protected GameObject interactionIndicator;

    public virtual void DisplayIndicator(bool isActive)
    {
        interactionIndicator.SetActive(isActive);
    }

    public abstract void Interact();
}
