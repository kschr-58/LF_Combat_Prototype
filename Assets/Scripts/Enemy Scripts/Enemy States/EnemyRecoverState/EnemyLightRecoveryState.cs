using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLightRecoveryState : EnemyRecoverState
{
    public EnemyLightRecoveryState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Recover (Light)";
        this.animationBool = "Recover (L)";
    }

    public override void Enter()
    {
        base.Enter();

        // Instantiate VFX
        ScreenEffectHandler.Instance.InstantiateVFX(enemyData.EffectLibrary.LandingEffect, enemyData.transform.position, Quaternion.identity, enemyData.transform.localScale);
    }


    protected override void AnimationEndEvent()
    {
        stateManager.ChangeState(stateManager._idleState);
    }
}
