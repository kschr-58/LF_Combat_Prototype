using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAerialState : PlayerState
{
    protected PlayerAerialState(PlayerData playerData) : base(playerData) {}

    public override void MoveHorizontally(float h_Axis)
    {
        nextVelocity.x = playerData.RunSpeed * h_Axis;
        nextVelocity.y = playerData.RB.velocity.y;

        playerData.RB.velocity = nextVelocity;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if (isFalling)
        {
            stateManager.ChangeState(stateManager._fallingState);
        }
    }

    public override void Jump()
    {
        return;
    }

    public override void Dodge()
    {
        if (playerData.DodgingComponent.CanDodge()) stateManager.ChangeState(stateManager._aerialDodgeState);
    }

    public override bool CanFlip()
    {
        return false;
    }
}
