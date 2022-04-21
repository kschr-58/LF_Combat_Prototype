using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAerialState_Falling : PlayerAerialState
{
    public PlayerAerialState_Falling(Player player) : base(player)
    {
        this.stateName = "Falling";
    }

    public override void ChangeAnimation()
    {
        m_animator.SetTrigger("Fall");
    }
}
