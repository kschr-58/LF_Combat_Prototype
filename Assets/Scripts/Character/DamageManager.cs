using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageManager : MonoBehaviour
{
    protected ScreenEffectHandler screenEffectHandler;

    private void Start()
    {
        screenEffectHandler = ScreenEffectHandler.Singleton;
    }

    public abstract void Launch();

    public abstract void ForwardLaunch();

    public abstract void StraightForwardLaunch();

    public abstract void Spike();

    public abstract void Shot();
}
