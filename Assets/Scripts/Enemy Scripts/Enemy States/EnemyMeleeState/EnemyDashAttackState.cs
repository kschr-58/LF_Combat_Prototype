using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDashAttackState : EnemyMeleeState
{
    public EnemyDashAttackState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Melee (Dash Attack)";
        this.animationBool = "Melee (Dash Attack)";

        decreasingVelocity = true;
    }

    public override void ExertMeleeVelocity()
    {
        nextVelocity.x = enemyData.DashAttackVelocity.x * enemyData.transform.localScale.x;
        nextVelocity.y = enemyData.DashAttackVelocity.y;

        enemyData.RB.velocity = nextVelocity;
    }

    protected override void AnimationEndEvent()
    {
        stateManager.ChangeState(stateManager._idleState);
    }
}
