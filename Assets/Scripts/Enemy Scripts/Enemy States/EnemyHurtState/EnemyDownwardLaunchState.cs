using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDownwardLaunchState : EnemyHurtState
{
    public EnemyDownwardLaunchState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Hurt (Downward Launch)" ;
        this.animationBool = "Hurt (Downward Launch)" ;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        // To ground bounce transition
        if (isGrounded) stateManager.ChangeState(stateManager._groundBounceState);
    }
}
