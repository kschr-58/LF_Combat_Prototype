using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerAerialState
{
    public PlayerJumpingState(PlayerData playerData) : base(playerData)
    {
        this.stateName = "Jumping";
        this.animationBool = "Jumping";
    }
    
    public override void EndJump()
    {
        playerData.JumpingComponent.ShortHop();
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
