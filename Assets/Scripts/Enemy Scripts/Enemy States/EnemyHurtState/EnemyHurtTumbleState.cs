using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtTumbleState : EnemyHurtState
{
    public EnemyHurtTumbleState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Hurt (Tumble)";
        this.animationBool = "Hurt (Tumble)";
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Mathf.Abs(enemyData.RB.velocity.x) < 10) stateManager.ChangeState(stateManager._dragState);
    }
}
