using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockdownRecoveryState : EnemyRecoverState
{
    public EnemyKnockdownRecoveryState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Recover (Knockdown)";
        this.animationBool = "Recover (Knockdown)";
    }

    protected override void AnimationEndEvent()
    {
        stateManager.ChangeState(stateManager._idleState);
    }
}
