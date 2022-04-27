using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTransmitter : MonoBehaviour
{
    public delegate void AnimationEnd();
    public event AnimationEnd OnAnimationEnd;

    #region Public Methods

    public void EndAnimation()
    {
        if (OnAnimationEnd == null) return;
        
        OnAnimationEnd();
    }

    #endregion
}
