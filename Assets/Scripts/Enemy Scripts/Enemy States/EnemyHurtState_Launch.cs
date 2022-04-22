using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtState_Launch : EnemyHurtState
{
    public EnemyHurtState_Launch(Enemy enemy) : base(enemy) {}

    protected override void ChangeGravity()
    {
        m_rb.gravityScale = enemy.GetLaunchGravity();
    }
}
