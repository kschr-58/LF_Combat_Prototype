using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStandingKickState : PlayerMeleeState
{
    public PlayerStandingKickState(PlayerData playerData) : base(playerData)
    {
        this.stateName = "Standing kick";
        this.animationBool = "Standing Kick";
        this.decreasingVelocity = true;
        this.velocityDecreaseModifier = 0.78f;
    }

    public override void Enter()
    {
        base.Enter();

        // Instantiate VFX
        Vector3 effectScale = playerData.transform.localScale;
        effectScale.x *= -1;
        
        ScreenEffectHandler.Singleton.InstantiateVFX(playerData.EffectLibrary.ForwardJumpEffect, playerData.transform.position, Quaternion.identity, effectScale);
    }

    protected override void ExertMeleeVelocity()
    {
        nextVelocity.x = playerData.StandingKickVelocity.x * playerData.transform.localScale.x;
        nextVelocity.y = playerData.StandingKickVelocity.y;

        playerData.RB.velocity = nextVelocity;
    }
}
