using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundBounceState : EnemyHurtState
{
    public EnemyGroundBounceState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Hurt (Ground Bounce)";
        this.animationBool = "Hurt (Ground Bounce)";
    }

    public override void Enter()
    {
        base.Enter();

        isStateLocked = true;

        enemyData.RB.gravityScale = enemyData.GroundBounceGravity;

        nextVelocity = enemyData.GroundBounceVelocity;
        nextVelocity.x *= enemyData.transform.localScale.x;

        enemyData.RB.velocity = nextVelocity;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isStateLocked) return;

        // To ground bounce transition
        if (isGrounded) stateManager.ChangeState(stateManager._idleState);
    }

    protected override void AnimationEndEvent()
    {
        isStateLocked = false;
    }
}
