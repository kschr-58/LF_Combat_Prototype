using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeState_AerialKick : PlayerMeleeState
{
    public PlayerMeleeState_AerialKick(Player player) : base(player)
    {
        this.stateName = "Aerial kick";
    }

    protected override void AnimationEndEvent()
    {
        if (!m_playerStateHandler.IsStateCurrentlyActive(this)) return;

        m_animator.SetTrigger("Stop Melee");

        m_meleeComponent.FinishMelee();
    }

    protected override void ChangeAnimation()
    {
        m_animator.SetTrigger("Aerial Kick");
    }
}
