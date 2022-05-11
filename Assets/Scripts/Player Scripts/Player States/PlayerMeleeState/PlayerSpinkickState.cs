using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpinkickState : PlayerMeleeState
{
    public PlayerSpinkickState(PlayerData playerData) : base(playerData)
    {
        this.stateName = "Melee (Spinkick)";
        this.animationBool = "Melee (Spinkick)";
        this.decreasingVelocity = true;
        this.velocityDecreaseModifier = 0.98f;
    }

    public override void Enter()
    {
        base.Enter();

        isGrounded = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isGrounded) stateManager.ChangeState(stateManager._landingState);
    }

    public override void EndJump()
    {
        playerData.JumpingComponent.ShortHop();
    }
    protected override void ExertMeleeVelocity()
    {
        nextVelocity.x = playerData.SpinkickVelocity.x * playerData.transform.localScale.x;
        nextVelocity.y = playerData.RB.velocity.y;

        playerData.RB.velocity = nextVelocity;
    }

}
