using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtGutState : EnemyHurtState
{
    public EnemyHurtGutState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Hurt (Gut)";
        this.animationBool = "Hurt (Gut)";
    }

    public override void Enter()
    {
        base.Enter();

        this.isStateLocked = true;

        enemyData.RB.gravityScale = enemyData.ShotGravity;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        HandleStateLock();
        
        // Following transitions can only occur while not state locked
        if (isStateLocked) return;

        // To recover transition
        if (isGrounded) stateManager.ChangeState(stateManager._lightRecoveryState);
    }


    private void HandleStateLock()
    {
        if (!isGrounded && isStateLocked) isStateLocked = false;
    }
}
