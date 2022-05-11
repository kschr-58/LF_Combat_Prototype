using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeAttack : MonoBehaviour
{
    [SerializeField] protected CharacterData characterData;
    [SerializeField] protected MeleeData meleeData;

    protected List<GameObject> targetsHit = new List<GameObject>();
    protected ScreenEffectHandler screenEffectHandler;
    protected int direction;

    #region Unity Callback Methods

    private void Start()
    {
        screenEffectHandler = ScreenEffectHandler.Singleton;
    }

    private void OnEnable()
    {
        targetsHit.Clear();
        direction = (int) characterData.transform.localScale.x;
    }

    #endregion

    #region Virtual Methods

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        // Target can only be hit once by the same hitbox
        if (targetsHit.Contains(col.gameObject)) return;

        targetsHit.Add(col.gameObject);

        // Gather target components
        DamageManager damageManager = col.GetComponentInParent<DamageManager>();
        Rigidbody2D colliderRB = col.GetComponentInParent<Rigidbody2D>();

        // Failsafe in case components are not present
        if (!damageManager || !colliderRB) return;

        Vector2 knockbackForce = meleeData.KnockBackForce;

        // Make horizontal knockback relative to player direction
        knockbackForce.x *= characterData.transform.localScale.x;

        // Apply knockback
        colliderRB.velocity = knockbackForce;

        // Make target face aggresor
        damageManager.FaceAggresor(direction);

        // Change Target State
        ChangeTargetState(damageManager);
    }

    protected virtual void ChangeTargetState(DamageManager damageManager)
    {
        if (meleeData.KnockBackType == AttackTypes.Launch) damageManager.Launch();
        if (meleeData.KnockBackType == AttackTypes.Forward_Launch) damageManager.ForwardLaunch();
        if (meleeData.KnockBackType == AttackTypes.Forward_Straight_Launch) damageManager.StraightForwardLaunch();
        if (meleeData.KnockBackType == AttackTypes.Spike) damageManager.Spike();
        if (meleeData.KnockBackType == AttackTypes.Light_Hurt) damageManager.LightHurt();
    }

    #endregion
}
