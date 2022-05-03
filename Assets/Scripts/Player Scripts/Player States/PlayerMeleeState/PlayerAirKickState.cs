using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirKickState : PlayerMeleeState
{
    public PlayerAirKickState(PlayerData playerData) : base(playerData)
    {
        this.stateName = "Air Kick";
        this.animationBool = "Aerial Kick";
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isGrounded)
        {
            stateManager.ChangeState(stateManager._landingState);
        }
    }

    public override void EndJump()
    {
        playerData.JumpingComponent.ShortHop();
    }

    protected override void ExertMeleeVelocity()
    {
        // nextVelocity.x = playerData.AerialKickVelocity.x * playerData.transform.localScale.x;
        // nextVelocity.y = playerData.AerialKickVelocity.y;

        // playerData.RB.velocity = nextVelocity;

        return;
    }
}
