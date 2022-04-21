using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAerialState_Jumping : PlayerAerialState
{
    public PlayerAerialState_Jumping(Player player) : base(player)
    {
        this.stateName = "Jumping";
    }

    public override void ChangeAnimation()
    {
        m_animator.SetTrigger("Jump");
    }
}
