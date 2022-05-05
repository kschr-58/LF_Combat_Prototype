using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtShotState : EnemyHurtState
{
    public EnemyHurtShotState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Hurt (Shot)";
        this.animationBool = "Hurt (L)";
    }

    public override void Enter()
    {
        base.Enter();

        isStateLocked = true;

        enemyData.RB.gravityScale = enemyData.ShotGravity;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        HandleStateLock();
        
        // Following transitions can only occur while not state locked
        if (isStateLocked) return;

        // To recover transition
        if (isGrounded) stateManager.ChangeState(stateManager._recoverLightState);
    }

    private void HandleStateLock()
    {
        if (!isGrounded && isStateLocked) isStateLocked = false;
    }
}
