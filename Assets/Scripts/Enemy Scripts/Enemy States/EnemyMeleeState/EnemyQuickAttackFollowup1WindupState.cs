using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQuickAttackFollowup1WindupState : EnemyMeleeState
{
    public EnemyQuickAttackFollowup1WindupState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Melee (Quick Attack Followup 1 Windup)";
        this.animationBool = "Melee (Quick Attack Followup 1 Windup)";
    }
    
    public override void ExertMeleeVelocity()
    {
        return;
    }

    protected override void AnimationEndEvent()
    {
        stateManager.ChangeState(stateManager._quickAttackFollowup1State);
    }
}
