using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState_Idle : PlayerGroundedState
{
    public PlayerGroundedState_Idle(Player player): base(player)
    {
        this.stateName = "Idle";
    }

    public override void ChangeAnimation()
    {
        m_animator.SetBool("Running", false);
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
