using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQuickAttackWindupState : EnemyMeleeState
{
    public EnemyQuickAttackWindupState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Melee (Quick Attack Windup)";
        this.animationBool = "Melee (Quick Attack Windup)";
    }
    
    public override void ExertMeleeVelocity()
    {
        return;
    }

    protected override void AnimationEndEvent()
    {
        stateManager.ChangeState(stateManager._quickAttackState);
    }
}
