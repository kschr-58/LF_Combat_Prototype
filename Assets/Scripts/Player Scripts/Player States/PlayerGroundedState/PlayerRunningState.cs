using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : PlayerGroundedState
{
    public PlayerRunningState(PlayerData player) : base(player)
    {
        this.stateName = "Running";
        this.animationBool = "Running";
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if (!isMoving)
        {
            stateManager.ChangeState(stateManager._idleState);
        }
    }

    public override void Dodge()
    {
        if (playerData.DodgingComponent.CanDodge()) stateManager.ChangeState(stateManager._runningDodgeState);
    }

    public override void Melee()
    {
        stateManager.ChangeState(stateManager._standingKickState);
    }

    protected override void AnimationEndEvent()
    {
        return;
    }
}
