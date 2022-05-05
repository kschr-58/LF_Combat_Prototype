using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRecoverLightState : EnemyRecoverState
{
    public EnemyRecoverLightState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Recover (Light)";
        this.animationBool = "Recover (L)";
    }

    protected override void AnimationEndEvent()
    {
        stateManager.ChangeState(stateManager._idleState);
    }
}
