using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStandingDodgeState : PlayerDodgeState
{
    public PlayerStandingDodgeState(PlayerData playerData) : base(playerData)
    {
        this.stateName = "Standing dodge";
        this.animationBool = "Standing Dodge";
    }

    public override void Enter()
    {
        base.Enter();

        playerData.Animator.SetBool("Moving Forward", false);

        playerData.DodgingComponent.StandingDodge();
    }
}
