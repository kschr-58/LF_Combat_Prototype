using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyGroundedState
{
    public EnemyIdleState(EnemyData enemyData) : base(enemyData)
    {
        this.animationBool = "Idle";
        this.stateName = "Idle";
    }

    protected override void AnimationEndEvent()
    {
        return;
    }
}
