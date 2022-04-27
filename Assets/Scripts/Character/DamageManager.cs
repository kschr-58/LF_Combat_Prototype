using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageManager : MonoBehaviour
{
    public abstract void Launch();

    public abstract void ForwardLaunch();

    public abstract void StraightForwardLaunch();

    protected virtual IEnumerator InstantiateVFX(Vector2 location, GameObject VFXPrefab)
    {
        yield return new WaitForEndOfFrame(); //FIXME sloppy solution to wait for character to turn around

        Vector3 parentScale = transform.localScale;
        GameObject newEffect = Instantiate(VFXPrefab, location, Quaternion.identity, ParticlesCollection.GetInstance().transform);

        newEffect.transform.localScale = parentScale;
    }
}
