using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Prop: MonoBehaviour
{
    protected virtual void Start()
    {
        ScreenEffectHandler.Instance.OnBigImpact += OnBigImpact;
    }

    protected virtual void Destroy()
    {
        ScreenEffectHandler.Instance.OnBigImpact -= OnBigImpact;
    }

    protected abstract void OnBigImpact();
}
