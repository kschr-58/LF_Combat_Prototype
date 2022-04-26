using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAerialDodgeState : PlayerDodgeState
{
    public PlayerAerialDodgeState(PlayerData playerData) : base(playerData)
    {
        this.stateName = "Aerial dodge";
        this.animationBool = "Aerial Dodge";
    }

    public override void Enter()
    {
        base.Enter();

        playerData.DodgingComponent.AerialDodge();
    }
}
