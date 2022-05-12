using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTumbleState : EnemyHurtState
{
    public EnemyTumbleState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Hurt (Tumble)";
        this.animationBool = "Hurt (Tumble)";
    }

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

        if (Mathf.Abs(enemyData.RB.velocity.x) < 10) stateManager.ChangeState(stateManager._dragState); //FIXME magic number
    }
}
