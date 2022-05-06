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

        if (isMoving) stateManager.ChangeState(stateManager._runningState);
    }
}
