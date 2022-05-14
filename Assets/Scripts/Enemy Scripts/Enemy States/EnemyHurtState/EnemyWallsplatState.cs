using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWallsplatState : EnemyHurtState
{
    public EnemyWallsplatState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Hurt (Wallsplat)";
        this.animationBool = "Hurt (Wallsplat)";
    }

    public override void Enter()
    {
        base.Enter();

        enemyData.RB.gravityScale = enemyData.WallSplatGravity;

        CameraController.Instance.ShakeScreen(1.5f, 1, 0.3f);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isGrounded) stateManager.ChangeState(stateManager._wallslumpState);
    }
}
