using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MeleeAttack
{
    EnemyData _enemyData;

    protected override void FetchRequiredComponents()
    {
        _enemyData = GetComponentInParent<EnemyData>();
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        // Target can only be hit once by the same hitbox
        if (targetsHit.Contains(col.gameObject)) return;

        targetsHit.Add(col.gameObject);

        // Gather target components
        DamageManager damageManager = col.GetComponentInParent<DamageManager>();
        Rigidbody2D colliderRB = col.GetComponentInParent<Rigidbody2D>();

        // Failsafe in case components are not present
        if (!damageManager || !colliderRB) return;

        Vector2 knockbackForce = meleeData.KnockBackForce;

        // Make horizontal knockback relative to player direction
        knockbackForce.x *= _enemyData.transform.localScale.x;

        //Apply knockback
        colliderRB.velocity = knockbackForce;

        //Change Target State
        ChangeTargetState(damageManager);

        //Make target face player
        damageManager.FaceAggresor(_enemyData.transform);
    }
}
