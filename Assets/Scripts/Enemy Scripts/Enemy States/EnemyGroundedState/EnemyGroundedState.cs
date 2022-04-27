using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyGroundedState : EnemyState
{
    public EnemyGroundedState(EnemyData enemyData) : base(enemyData) {}

    public override void Enter()
    {
        base.Enter();

        enemyData.RB.gravityScale = enemyData.DefaultGravity;
    }
}
