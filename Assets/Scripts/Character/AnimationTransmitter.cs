using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTransmitter : MonoBehaviour
{
    public delegate void AnimationEnd();
    public event AnimationEnd OnAnimationEnd;
    public delegate void AddVelocity(Vector2 velocity);
    public event AddVelocity OnVelocityAdded;

    private Vector2 _nextVelocity;

    #region Public Methods

    public void EndAnimation()
    {
        OnAnimationEnd?.Invoke();
    }

    private void AddHorizontalVelocity(AnimationVelocityData velocityData)
    {
        _nextVelocity.x = velocityData.horizontalVelocity;
        _nextVelocity.y = velocityData.verticalVelocity;

        OnVelocityAdded?.Invoke(_nextVelocity);
    }

    #endregion
}
