using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeAttack : MonoBehaviour
{
    [SerializeField] protected CharacterData characterData;
    [SerializeField] protected MeleeData meleeData;

    protected List<CharacterData> targetsHit = new List<CharacterData>();
    protected ScreenEffectHandler screenEffectHandler;
    protected int direction;

    #region Unity Callback Methods

    private void Start()
    {
        screenEffectHandler = ScreenEffectHandler.Instance;
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
        // Gather target components
        CharacterData targetData = col.GetComponentInParent<CharacterData>();
        Rigidbody2D colliderRB = col.GetComponentInParent<Rigidbody2D>();

        // Failsafe in case components are not present
        if (!targetData || !colliderRB) return;

        // Target can only be hit once by the same hitbox
        // if (targetsHit.Contains(targetData)) return;

        // FIXME Only hit a single target (?)
        if (targetsHit.Count > 0) return;

        targetsHit.Add(targetData);

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

        DamageTarget(targetData);
    }

    protected virtual void ChangeTargetState(HurtManager hurtManager)
    {
        if (meleeData.KnockBackType == AttackTypes.Launch) hurtManager.Launch();
        if (meleeData.KnockBackType == AttackTypes.Forward_Launch) hurtManager.ForwardLaunch();
        if (meleeData.KnockBackType == AttackTypes.Forward_Straight_Launch) hurtManager.StraightForwardLaunch();
        if (meleeData.KnockBackType == AttackTypes.Spike) hurtManager.Spike();
        if (meleeData.KnockBackType == AttackTypes.Light_Hurt) hurtManager.LightHurt();
        if (meleeData.KnockBackType == AttackTypes.Gut_Hurt) hurtManager.GutHurt();
        if (meleeData.KnockBackType == AttackTypes.Grounded_Execution) hurtManager.GroundedExecution();
    }

    #endregion

    #region  Abstract Methods

    protected abstract void DamageTarget(CharacterData targetData);

    #endregion
}
