using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUppercutState : PlayerMeleeState
{
    public PlayerUppercutState(PlayerData playerData) : base(playerData)
    {
        this.stateName = "Melee (Uppercut)";
        this.animationBool = "Melee (Uppercut)";
    }

    public override void Enter()
    {
        base.Enter();

        // Instantiate VFX
        ScreenEffectHandler.Instance.InstantiateVFX(playerData.EffectLibrary.ForwardJumpEffect, playerData.transform.position, Quaternion.identity, playerData.transform.localScale);
    }

    protected override void ExertMeleeVelocity()
    {
        nextVelocity.x = playerData.UppercutVelocity.x * playerData.transform.localScale.x;
        nextVelocity.y = playerData.UppercutVelocity.y;

        playerData.RB.velocity = nextVelocity;
    }
}
