using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeState_Uppercut : PlayerMeleeState
{
    public PlayerMeleeState_Uppercut(Player player) : base(player) 
    {
        this.stateName = "Uppercut";
    }

    #region Override Implementations

    protected override void ChangeAnimation()
    {
        m_animator.SetTrigger("Test Melee");
    }

    protected override void AnimationEndEvent()
    {
        if (!m_playerStateHandler.IsStateCurrentlyActive(this)) return;

        m_meleeComponent.FinishMelee();
    }

    #endregion
}
