using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState_Landing : PlayerGroundedState
{
    public PlayerGroundedState_Landing(Player player) : base(player)
    {
        this.stateName = "Landing";
    }

    public override void ChangeAnimation()
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
}
