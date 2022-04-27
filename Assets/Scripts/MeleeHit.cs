using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeHit : MonoBehaviour
{
    [SerializeField] protected MeleeData meleeData;

    protected List<GameObject> targetsHit = new List<GameObject>();
    protected ScreenEffectHandler screenEffectHandler;

    #region Unity Callback Methods
    private void Start()
    {
        screenEffectHandler = ScreenEffectHandler.GetInstance();

        FetchRequiredComponents();
    }

    private void OnEnable()
    {
        targetsHit.Clear();
    }

    #endregion

    #region Abstract Methods

    protected abstract void FetchRequiredComponents();

    protected abstract void OnTriggerEnter2D(Collider2D col);

    #endregion
}
