using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Dodging : PlayerState
{
    public PlayerState_Dodging(Player player) : base(player)
    {
        this.stateName = "Dodging";
    }

    public override void ChangeAnimation()
    {
        bool isMovingBackward = player.transform.localScale.x != Mathf.Sign(m_rB.velocity.x);

        m_animator.SetBool("Moving Backwards", isMovingBackward);
        m_animator.SetBool("Dodging", true);
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

    public override void MoveHorizontally(float h_Axis)
    {
        return;
    }
}
