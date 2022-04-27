using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMeleeState : PlayerState
{
    protected float velocityDecreaseModifier = 0.9f;
    protected bool decreasingVelocity;

    public PlayerMeleeState(PlayerData playerData) : base(playerData) {}

    #region Override Methods

    public override void Enter()
    {
        base.Enter();

        ExertMeleeVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (!decreasingVelocity) return;

        DecreaseVelocity();
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

    protected override void AnimationEndEvent()
    {
        EndMelee();
    }

    #endregion

    #region Virtual Methods

    protected virtual void EndMelee()
    {
        stateManager.ChangeState(stateManager._fallingState);
    }

    protected virtual void DecreaseVelocity()
    {
        playerData.RB.velocity *= velocityDecreaseModifier;
    }

    #endregion

    #region Abstract Methods

    protected abstract void ExertMeleeVelocity();

    #endregion
}
