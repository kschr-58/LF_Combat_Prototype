using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQuickAttackFollowup1State : EnemyMeleeState
{
    public EnemyQuickAttackFollowup1State(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Melee (Quick Attack Followup 1)";
        this.animationBool = "Melee (Quick Attack Followup 1)";
        this.meleeDelayTime = 0.5f;

        decreasingVelocity = true;
    }

    public override void Enter()
    {
        enemyData.TargetChasingComponent.FlipTowardsTarget();

        base.Enter();
    }

    public override void ExertMeleeVelocity()
    {
        nextVelocity.x = enemyData.QuickAttackFollowup1Velocity.x * enemyData.transform.localScale.x;
        nextVelocity.y = enemyData.QuickAttackFollowup1Velocity.y;

        enemyData.RB.velocity = nextVelocity;
    }

    protected override void AnimationEndEvent()
    {
        stateManager.ChangeState(stateManager._idleState);
    }
}
