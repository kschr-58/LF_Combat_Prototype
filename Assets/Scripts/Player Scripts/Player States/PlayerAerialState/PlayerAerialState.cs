using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAerialState : PlayerState
{
    protected PlayerAerialState(PlayerData playerData) : base(playerData) {}

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if (!isJumping)
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

    public override void Melee()
    {
        if (verticalInput == -1)
        {
            stateManager.ChangeState(stateManager._spikeState);
        }

        else if (horizontalInput == playerData.transform.localScale.x) stateManager.ChangeState(stateManager._spinkickState);

        else stateManager.ChangeState(stateManager._aerialKickState);
    }

    public override bool CanFlip()
    {
        return false;
    }
}
