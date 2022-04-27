using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageManager : MonoBehaviour
{
    public abstract void Launch();

    public abstract void ForwardLaunch();

    public abstract void StraightForwardLaunch();
}
