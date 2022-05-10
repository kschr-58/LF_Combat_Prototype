using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQuickAttackState : EnemyMeleeState
{
    public EnemyQuickAttackState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Melee (Quick Attack)";
        this.animationBool = "Melee (Quick Attack)";
        this.meleeDelayTime = 0.5f;

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
        // Perform followup check
        float randomNum = Random.Range(0, 101);

        if (randomNum <= enemyData.followupChance)
        {
            stateManager.ChangeState(stateManager._quickAttackFollowup1WindupState);
            return;
        }

        stateManager.ChangeState(stateManager._idleState);
    }
}
