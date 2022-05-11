using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwipeState : PlayerMeleeState
{
    public PlayerSwipeState(PlayerData playerData) : base(playerData)
    {
        this.stateName = "Melee (Swipe)";
        this.animationBool = "Melee (Swipe)";
    }

    protected override void ExertMeleeVelocity()
    {
        nextVelocity.x = playerData.SwipeVelocity.x * playerData.transform.localScale.x;
        nextVelocity.y = playerData.SwipeVelocity.y;

        playerData.RB.velocity = nextVelocity;
    }

    protected override void EndMelee()
    {
        stateManager.ChangeState(stateManager._idleState);
    }
}
