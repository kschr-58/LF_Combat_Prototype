using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyGroundedState
{
    public EnemyIdleState(EnemyData enemyData) : base(enemyData)
    {
        this.animationBool = "Idle";
        this.stateName = "Idle";
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        enemyData.TargetChasingComponent.FlipTowardsTarget();
        
        if (isMoving) stateManager.ChangeState(stateManager._runningState);
    }

    public override void Melee()
    {
        stateManager.ChangeState(stateManager._quickAttackWindupState);
    }
}
