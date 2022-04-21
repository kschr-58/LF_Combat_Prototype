using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState_Running : PlayerGroundedState
{
    public PlayerGroundedState_Running(Player player): base(player)
    {
        this.stateName = "Running";
    }

    public override void ChangeAnimation()
    {
        m_animator.SetBool("Running", true);
    }

    public override bool GroundedCanFlip()
    {
        return true;
    }

    public override void GroundedDodge()
    {
        m_dodgingComponent.RunningDodge();
    }
}
