using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAerialState_Upward : PlayerAerialState
{
    public PlayerAerialState_Upward(Player player) : base(player)
    {
        this.stateName = "Upward";
    }

    protected override void ChangeAnimation()
    {
        m_animator.SetTrigger("Upward Trajectory");
    }
}
