using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageManager : MonoBehaviour
{
    public abstract void Launch();

    public abstract void ForwardLaunch();

    public abstract void StraightForwardLaunch();

    protected virtual void InstantiateVFX(Vector2 location, GameObject VFXPrefab)
    {
        Vector3 parentScale = transform.localScale;
        GameObject newEffect = Instantiate(VFXPrefab, location, Quaternion.identity, ParticlesCollection.GetInstance().transform);

        newEffect.transform.localScale = parentScale;
    }
}
