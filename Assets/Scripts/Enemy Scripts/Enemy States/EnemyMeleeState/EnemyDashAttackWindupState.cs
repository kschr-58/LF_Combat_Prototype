using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDashAttackWindupState : EnemyMeleeState
{
    public EnemyDashAttackWindupState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Melee (Dash Attack Windup)";
        this.animationBool = "Melee (Dash Attack Windup)";
    }

    public override void ExertMeleeVelocity()
    {
        return;
    }

    protected override void AnimationEndEvent()
    {
        stateManager.ChangeState(stateManager._dashAttackState);
    }
}
