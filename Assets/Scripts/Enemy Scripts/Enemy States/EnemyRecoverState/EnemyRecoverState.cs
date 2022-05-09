using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyRecoverState : EnemyState
{
    protected EnemyRecoverState(EnemyData enemyData) : base(enemyData) {}

    public override void Melee()
    {
        return;
    }

}
