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

        if (enemyData.SidesCollider.IsTouchingLayers(enemyData.TerrainLayerMask)) stateManager.ChangeState(stateManager._wallsplatState);

        if (isGrounded && !isAnimationLocked && Mathf.Abs(enemyData.RB.velocity.x) > 8) stateManager.ChangeState(stateManager._tumbleState);

        else if (isGrounded && !isAnimationLocked) stateManager.ChangeState(stateManager._idleState);
    }

    public override bool CanFlip()
    {
        return true;
    }
}
