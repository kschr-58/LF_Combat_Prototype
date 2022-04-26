using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUppercutState : PlayerMeleeState
{
    public PlayerUppercutState(PlayerData playerData) : base(playerData)
    {
        this.stateName = "Uppercut";
        this.animationBool = "Uppercut";
    }

    protected override void ExertMeleeVelocity()
    {
        nextVelocity.x = playerData.UppercutVelocity.x * playerData.transform.localScale.x;
        nextVelocity.y = playerData.UppercutVelocity.y;

        playerData.RB.velocity = nextVelocity;
    }
}
