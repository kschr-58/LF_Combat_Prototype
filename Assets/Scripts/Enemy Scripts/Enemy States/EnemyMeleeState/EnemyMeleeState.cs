using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMeleeState : EnemyState
{
    protected float velocityDecreaseModifier = 0.9f;
    protected bool decreasingVelocity;

    public EnemyMeleeState(EnemyData enemyData) : base(enemyData) {}

    public override void Enter()
    {
        base.Enter();

        ExertMeleeVelocity();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (decreasingVelocity) DecreaseVelocity();
    }

    public abstract void ExertMeleeVelocity();

    protected virtual void DecreaseVelocity()
    {
        enemyData.RB.velocity *= velocityDecreaseModifier;
    }
}
