using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWallslumpState : EnemyHurtState
{
    public EnemyWallslumpState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Hurt (Wallslump)";
        this.animationBool = "Hurt (Wallslump)";
    }
}
