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
        float targetDistance = enemyData.TargetChasingComponent.GetDistanceToTarget();

        if (targetDistance <= enemyData.StandingMeleeProximity) stateManager.ChangeState(stateManager._quickAttackWindupState);
        else stateManager.ChangeState(stateManager._dashAttackWindupState);
    }

    public override float GetMeleeProximity()
    {
        return enemyData.RunningMeleeProximity;
    }
}
