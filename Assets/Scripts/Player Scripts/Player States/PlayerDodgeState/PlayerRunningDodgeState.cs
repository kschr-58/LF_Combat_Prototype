using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningDodgeState : PlayerDodgeState
{
    public PlayerRunningDodgeState(PlayerData playerData) : base(playerData)
    {
        this.stateName = "Running Dodge";
        this.animationBool = "Running Dodge";
    }

    public override void Enter()
    {
        base.Enter();

        playerData.DodgingComponent.RunningDodge();
    }
}
