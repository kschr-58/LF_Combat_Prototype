using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerExecutionState : PlayerState
{
    public PlayerExecutionState(PlayerData playerData) : base(playerData) {}

    public override bool CanFlip()
    {
        return false;
    }

    public override void Dodge()
    {
       return;
    }

    public override void EndJump()
    {
       return;
    }

    public override void Jump()
    {
       return;
    }

    public override void Melee()
    {
       return;
    }
}
