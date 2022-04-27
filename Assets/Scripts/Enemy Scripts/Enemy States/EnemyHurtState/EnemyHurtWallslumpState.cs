using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtWallslumpState : EnemyHurtState
{
    public EnemyHurtWallslumpState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Hurt (Wallslump)";
        this.animationBool = "Hurt (Wallslump)";
    }
}
