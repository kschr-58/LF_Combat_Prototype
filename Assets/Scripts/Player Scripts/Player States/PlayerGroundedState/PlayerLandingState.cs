using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandingState : PlayerGroundedState
{
    public PlayerLandingState(PlayerData playerData) : base(playerData)
    {
        this.stateName = "Landing";
        this.animationBool = "Landing";
    }

    public override void Enter()
    {
        base.Enter();

        // Instantiate VFX
        ScreenEffectHandler.Singleton.InstantiateVFX(playerData.EffectLibrary.LandingEffect, playerData.transform.position, Quaternion.identity, playerData.transform.localScale);
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
        stateManager.ChangeState(stateManager._swipeState);
    }

    public override bool CanFlip()
    {
        return false;
    }

    protected override void AnimationEndEvent()
    {
        stateManager.ChangeState(stateManager._idleState);
    }
}
