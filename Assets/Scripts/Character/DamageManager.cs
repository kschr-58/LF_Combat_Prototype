using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageManager : MonoBehaviour
{
    [SerializeField] protected CharacterData characterData;
    
    protected ScreenEffectHandler screenEffectHandler;

    private void Start()
    {
        screenEffectHandler = ScreenEffectHandler.Singleton;
    }

    #region Virtual Methods

    public virtual void FaceAggresor(Transform aggresor)
    {
        Vector3 newScale = characterData.transform.localScale;

        float direction = Mathf.Sign(aggresor.position.x - characterData.transform.position.x);

        newScale.x = direction;

        characterData.transform.localScale = newScale;
    }

    #endregion

    #region Abstract Methods

    public abstract void Launch();

    public abstract void ForwardLaunch();

    public abstract void StraightForwardLaunch();

    public abstract void Spike();

    public abstract void Shot();

    #endregion
}
