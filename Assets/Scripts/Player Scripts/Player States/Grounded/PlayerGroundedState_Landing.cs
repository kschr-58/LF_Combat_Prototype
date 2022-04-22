using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState_Landing : PlayerGroundedState
{
    public PlayerGroundedState_Landing(Player player) : base(player)
    {
        this.stateName = "Landing";
    }

    protected override void ChangeAnimation()
    {
        m_animator.SetTrigger("Land");
    }

    public override bool GroundedCanFlip()
    {
        return true;
    }

    public override void GroundedDodge()
    {
        m_dodgingComponent.StandingDodge();
    }

    public override void Melee()
    {
        return;
    }

    protected override void AnimationEndEvent()
    {
        if (!m_playerStateHandler.IsStateCurrentlyActive(this)) return;

        m_playerStateHandler.ToIdleState();
    }
}
