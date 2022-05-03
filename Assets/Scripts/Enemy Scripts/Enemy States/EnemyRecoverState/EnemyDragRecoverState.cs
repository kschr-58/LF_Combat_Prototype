using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDragRecoverState : EnemyRecoverState
{
    public EnemyDragRecoverState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Recover (Drag)";
        this.animationBool = "Recover (Drag)";
    }

    protected override void AnimationEndEvent()
    {
        stateManager.ChangeState(stateManager._idleState);
    }
}
