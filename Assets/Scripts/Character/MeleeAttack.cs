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
        CharacterData targetData = col.GetComponentInParent<CharacterData>();
        Rigidbody2D colliderRB = col.GetComponentInParent<Rigidbody2D>();

        // Failsafe in case components are not present
        if (!targetData || !colliderRB) return;

        Vector2 knockbackForce = meleeData.KnockBackForce;

        // Make horizontal knockback relative to player direction
        knockbackForce.x *= characterData.transform.localScale.x;

        // Apply knockback
        colliderRB.velocity = knockbackForce;

        // Make target face aggresor
        targetData.HurtManager.FaceAggresor(direction);

        // Change Target State
        ChangeTargetState(targetData.HurtManager);

        // Damage target
        targetData.DamageSystem.DealDamage(meleeData.Damage);
    }

    protected virtual void ChangeTargetState(HurtManager hurtManager)
    {
        if (meleeData.KnockBackType == AttackTypes.Launch) hurtManager.Launch();
        if (meleeData.KnockBackType == AttackTypes.Forward_Launch) hurtManager.ForwardLaunch();
        if (meleeData.KnockBackType == AttackTypes.Forward_Straight_Launch) hurtManager.StraightForwardLaunch();
        if (meleeData.KnockBackType == AttackTypes.Spike) hurtManager.Spike();
        if (meleeData.KnockBackType == AttackTypes.Light_Hurt) hurtManager.LightHurt();
    }

    #endregion
}
