using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerGroundedState: PlayerState
{
    protected PlayerGroundedState(Player player): base(player) {}

    #region Override Implementations

    public override void MoveHorizontally(float h_Axis)
    {
        nextVelocity.x = h_Axis * runSpeed;
        nextVelocity.y = m_rB.velocity.y;

        m_rB.velocity = nextVelocity;
    }

    public override void Jump()
    {
        m_jumpingComponent.GroundedJump();
    }

    public override void EndJump()
    {
        m_jumpingComponent.ShortHop();
    }

    public override void Dodge()
    {
        GroundedDodge();
    }

    protected override void AnimationEndEvent()
    {
        return;
    }

    public override bool CanFlip()
    {
        return GroundedCanFlip();
    }

    #endregion

    #region Abstract Methods

    public abstract void GroundedDodge();

    public abstract bool GroundedCanFlip();

    #endregion
}
