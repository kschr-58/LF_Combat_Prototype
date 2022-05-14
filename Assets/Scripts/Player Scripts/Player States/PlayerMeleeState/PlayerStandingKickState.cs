using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStandingKickState : PlayerMeleeState
{
    public PlayerStandingKickState(PlayerData playerData) : base(playerData)
    {
        this.stateName = "Melee (Standing Kick)";
        this.animationBool = "Melee (Standing Kick)";
        this.decreasingVelocity = true;
        this.velocityDecreaseModifier = 0.85f; //FIXME magic number
    }

    public override void Enter()
    {
        base.Enter();

        // Instantiate VFX
        Vector3 effectScale = playerData.transform.localScale;
        effectScale.x *= -1;
        
        ScreenEffectHandler.Instance.InstantiateVFX(playerData.EffectLibrary.ForwardJumpEffect, playerData.transform.position, Quaternion.identity, effectScale);
    }

    protected override void ExertMeleeVelocity()
    {
        nextVelocity.x = playerData.StandingKickVelocity.x * playerData.transform.localScale.x;
        nextVelocity.y = playerData.StandingKickVelocity.y;

        playerData.RB.velocity = nextVelocity;
    }
}
