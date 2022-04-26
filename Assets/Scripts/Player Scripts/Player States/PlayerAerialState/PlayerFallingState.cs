using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerAerialState
{
    public PlayerFallingState(PlayerData playerData) : base(playerData)
    {
        this.stateName = "Falling";
        this.animationBool = "Falling";
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
        return;
    }

    public override void Jump()
    {
        return;
    }

    public override void Melee()
    {
        stateManager.ChangeState(stateManager._aerialKickState);
    }

    protected override void AnimationEndEvent()
    {
        return;
    }
}
