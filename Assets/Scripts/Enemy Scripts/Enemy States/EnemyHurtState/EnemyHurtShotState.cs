using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtShotState : EnemyHurtState
{
    public EnemyHurtShotState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Hurt (Shot)";
        this.animationBool = "Hurt (Shot)";
    }

    public override void Enter()
    {
        base.Enter();

        enemyData.RB.gravityScale = enemyData.ShotGravity;
    }
}
