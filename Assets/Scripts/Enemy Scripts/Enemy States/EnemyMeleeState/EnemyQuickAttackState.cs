using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQuickAttackState : EnemyMeleeState
{
    public EnemyQuickAttackState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Melee (Quick Attack)";
        this.animationBool = "Melee (Quick Attack)";

        decreasingVelocity = true;
    }

    public override void ExertMeleeVelocity()
    {
        nextVelocity.x = enemyData.QuickAttackVelocity.x * enemyData.transform.localScale.x;
        nextVelocity.y = enemyData.QuickAttackVelocity.y;

        enemyData.RB.velocity = nextVelocity;
    }

    protected override void AnimationEndEvent()
    {
        stateManager.ChangeState(stateManager._idleState);
    }
}
