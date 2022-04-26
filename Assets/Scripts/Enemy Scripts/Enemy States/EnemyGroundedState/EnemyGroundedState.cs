using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyGroundedState : EnemyState
{
    public EnemyGroundedState(EnemyData enemyData) : base(enemyData) {}

    public override void Launch()
    {
        stateManager.ChangeState(stateManager._launchState);
    }
}
