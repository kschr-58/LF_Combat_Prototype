using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtWallsplatState : EnemyHurtState
{
    public EnemyHurtWallsplatState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Hurt (Wallsplat)";
        this.animationBool = "Hurt (Wallsplat)";
    }

    public override void Enter()
    {
        base.Enter();

        enemyData.RB.gravityScale = enemyData.WallSplatGravity;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isGrounded) stateManager.ChangeState(stateManager._wallslumpState);
    }
}
