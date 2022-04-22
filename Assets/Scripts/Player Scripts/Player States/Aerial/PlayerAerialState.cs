using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAerialState : PlayerState
{
    protected PlayerAerialState(Player player): base(player) {}

    #region Override implementations

    public override void MoveHorizontally(float h_Axis)
    {
        nextVelocity.x = h_Axis * runSpeed;
        nextVelocity.y = m_rB.velocity.y;

        m_rB.velocity = nextVelocity;
    }

    public override void Jump()
    {
        // m_jumpingComponent.AerialJump();
        return;
    }

    public override void EndJump()
    {
        m_jumpingComponent.ShortHop();
    }

    public override void Dodge()
    {
        m_dodgingComponent.AerialDodge();
    }

    public override void Melee()
    {
        return;
    }

    public override bool CanFlip()
    {
        return false;
    }

    protected override void AnimationEndEvent()
    {
        return;
    }

    #endregion
}
