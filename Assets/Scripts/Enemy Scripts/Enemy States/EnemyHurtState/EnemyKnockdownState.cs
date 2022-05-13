using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockdownState : EnemyHurtState
{
    public EnemyKnockdownState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Hurt (Knockdown)";
        this.animationBool = "Hurt (Knockdown)";
    }

    public override void Enter()
    {
        base.Enter();

        isStateLocked = true;

        // Instantiate VFX
        ScreenEffectHandler.Singleton.InstantiateVFX(enemyData.EffectLibrary.LandingEffect, enemyData.transform.position, Quaternion.identity, enemyData.transform.localScale);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isStateLocked) return;

        if (Mathf.Abs(enemyData.RB.velocity.x) <= 0.1f) stateManager.ChangeState(stateManager._knockdownRecoveryState); //FIXME magic number
    }

    protected override void AnimationEndEvent()
    {
        isStateLocked = false;
    }
}
