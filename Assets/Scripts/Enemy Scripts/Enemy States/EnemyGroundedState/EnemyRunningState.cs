using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunningState : EnemyGroundedState
{
    public EnemyRunningState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Running";
        this.animationBool = "Running";
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isMoving) stateManager.ChangeState(stateManager._idleState);
    }

    public override void Melee()
    {
        stateManager.ChangeState(stateManager._dashAttackWindupState);
    }
}
