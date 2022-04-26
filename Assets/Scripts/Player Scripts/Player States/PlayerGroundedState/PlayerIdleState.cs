using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerData player) : base(player)
    {
        this.stateName = "Idle";
        this.animationBool = "Idle";
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if (isMoving)
        {
            stateManager.ChangeState(stateManager._runningState);
        }
    }

    public override void Dodge()
    {
        if (playerData.DodgingComponent.CanDodge()) stateManager.ChangeState(stateManager._standingDodgeState);
    }

    public override void Melee()
    {
        stateManager.ChangeState(stateManager._uppercutState);
    }

    protected override void AnimationEndEvent()
    {
        return;
    }
}
