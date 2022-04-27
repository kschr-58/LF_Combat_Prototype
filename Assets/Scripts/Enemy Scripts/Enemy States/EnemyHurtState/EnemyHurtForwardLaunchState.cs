using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtForwardLaunchState : EnemyHurtState
{
    public EnemyHurtForwardLaunchState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Hurt (Forward Launch)";
        this.animationBool = "Hurt (Forward Launch)";
    }

    public override void Enter()
    {
        base.Enter();

        isAnimationLocked = true;

        enemyData.RB.gravityScale = enemyData.LaunchGravity;
    }

    public override void LogicUpdate()
    {
        if (!isGrounded && isAnimationLocked) isAnimationLocked = false;

        if (isGrounded && !isAnimationLocked) stateManager.ChangeState(stateManager._idleState);
    }
}
