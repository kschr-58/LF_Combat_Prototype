using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStandingKickState : PlayerMeleeState
{
    public PlayerStandingKickState(PlayerData playerData) : base(playerData)
    {
        this.stateName = "Standing kick";
        this.animationBool = "Standing Kick";
    }

    protected override void ExertMeleeVelocity()
    {
        nextVelocity.x = playerData.StandingKickVelocity.x * playerData.transform.localScale.x;
        nextVelocity.y = playerData.StandingKickVelocity.y;

        playerData.RB.velocity = nextVelocity;
    }
}
