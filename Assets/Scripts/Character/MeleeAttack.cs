using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeAttack : MonoBehaviour
{
    [SerializeField] protected MeleeData meleeData;

    protected List<GameObject> targetsHit = new List<GameObject>();
    protected ScreenEffectHandler screenEffectHandler;

    #region Unity Callback Methods
    private void Start()
    {
        screenEffectHandler = ScreenEffectHandler.Singleton;

        FetchRequiredComponents();
    }

    private void OnEnable()
    {
        targetsHit.Clear();
    }

    #endregion

    #region Virtual Methods

    protected virtual void ChangeTargetState(DamageManager damageManager)
    {
        if (meleeData.KnockBackType == AttackTypes.Launch) damageManager.Launch();
        if (meleeData.KnockBackType == AttackTypes.Forward_Launch) damageManager.ForwardLaunch();
        if (meleeData.KnockBackType == AttackTypes.Forward_Straight_Launch) damageManager.StraightForwardLaunch();
    }

    #endregion

    #region Abstract Methods

    protected abstract void FetchRequiredComponents();

    protected abstract void OnTriggerEnter2D(Collider2D col);

    #endregion
}
