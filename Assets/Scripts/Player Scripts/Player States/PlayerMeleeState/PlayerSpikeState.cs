using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpikeState : PlayerMeleeState
{
    public PlayerSpikeState(PlayerData playerData) : base(playerData)
    {
        this.stateName = "Melee (Spike)";
        this.animationBool = "Melee (Spike)";
        this.decreasingVelocity = true;
        this.velocityDecreaseModifier = 0.96f; //FIXME magic number
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isGrounded) stateManager.ChangeState(stateManager._landingState);
    }

    protected override void ExertMeleeVelocity()
    {
        nextVelocity.x = playerData.SpikeVelocity.x * playerData.transform.localScale.x;
        nextVelocity.y = playerData.SpikeVelocity.y;

        playerData.RB.velocity = nextVelocity;
    }
}
