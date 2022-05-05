using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerGroundedState : PlayerState
{
    protected bool isMoving;

    public PlayerGroundedState(PlayerData playerData) : base(playerData) {}

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        isMoving = Mathf.Abs(playerData.RB.velocity.x) > playerData.RunningTreshold;

        if (isJumping)
        {
            stateManager.ChangeState(stateManager._jumpingState);
        }

        if (isFalling)
        {
            stateManager.ChangeState(stateManager._fallingState);
        }
    }

    public override bool CanFlip()
    {
        return true;
    }

    public override void Jump()
    {
        playerData.JumpingComponent.GroundedJump();
        stateManager.ChangeState(stateManager._jumpingState);
    }

    public override void EndJump()
    {
        return;
    }
}
