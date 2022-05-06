using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyGroundedState : EnemyState
{
    protected bool isMoving;

    public EnemyGroundedState(EnemyData enemyData) : base(enemyData) {}

    public override void Enter()
    {
        base.Enter();

        enemyData.SmokeTrail.EnableTrail();
    }

    public override void Exit()
    {
        base.Exit();

        enemyData.SmokeTrail.DisableTrail();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        enemyData.TargetChasingComponent?.ChaseTarget();
        
        isMoving = Mathf.Abs(enemyData.RB.velocity.x) >= enemyData.RunningTreshold;
    }

    public override bool CanFlip()
    {
        return true;
    }

    protected override void AnimationEndEvent()
    {
        return;
    }
}
