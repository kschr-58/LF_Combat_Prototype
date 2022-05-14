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
        GameObject vfx = playerData.EffectLibrary.LandingEffect;
        Vector2 feetPos = playerData.FeetCollider.transform.position;
        Vector3 playerScale = playerData.transform.localScale;

        ScreenEffectHandler.Instance.InstantiateVFX(vfx, feetPos, Quaternion.identity, playerScale);
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
