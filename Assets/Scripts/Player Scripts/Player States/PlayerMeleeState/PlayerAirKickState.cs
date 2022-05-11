using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirKickState : PlayerMeleeState
{
    public PlayerAirKickState(PlayerData playerData) : base(playerData)
    {
        this.stateName = "Melee (Aerial Kick)";
        this.animationBool = "Melee (Aerial Kick)";
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
        Vector2 currentVelocity = playerData.RB.velocity;

        nextVelocity.x = currentVelocity.x;
        nextVelocity.y = currentVelocity.y > 0 ? currentVelocity.y : playerData.AerialKickVelocity.y;

        playerData.RB.velocity = nextVelocity;
    }
}
