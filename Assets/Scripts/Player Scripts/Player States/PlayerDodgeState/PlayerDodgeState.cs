using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodgeState : PlayerState
{
    public PlayerDodgeState(PlayerData playerData) : base(playerData) {}

    #region Override Methods

    public override void Enter()
    {
        base.Enter();

        playerData.DodgingComponent.OnDodge += OnDodgeChange;

        isMovingForward = Mathf.Sign(playerData.RB.velocity.x) == Mathf.Sign(playerData.transform.localScale.x);

        playerData.Animator.SetBool("Moving Forward", isMovingForward);
    }

    public override void Exit()
    {
        base.Exit();
        
        playerData.DodgingComponent.OnDodge -= OnDodgeChange;

        playerData.Animator.SetBool("Moving Forward", false);
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
        return;
    }

    #endregion

    #region Virtual Methods

    protected virtual void OnDodgeChange(bool isDodging)
    {
        if (!isDodging) EndDodge();
    }

    protected virtual void EndDodge()
    {
        stateManager.ChangeState(stateManager._fallingState);
    }

    #endregion
}
