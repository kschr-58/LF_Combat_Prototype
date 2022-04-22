using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(Enemy enemy) : base(enemy) 
    {
        m_rb.gravityScale = enemy.GetDefaultGravity();
    }

    public override void ChangeAnimation()
    {
        return;
    }
}
