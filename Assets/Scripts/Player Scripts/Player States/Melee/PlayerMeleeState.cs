using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMeleeState : PlayerState
{
    public PlayerMeleeState(Player player) : base(player)
    {
    }

    #region Override Implementations

    public override void InitializeState()
    {
        base.InitializeState();
    }

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

    public override void MoveHorizontally(float h_Axis)
    {
        return;
    }

    #endregion
}
