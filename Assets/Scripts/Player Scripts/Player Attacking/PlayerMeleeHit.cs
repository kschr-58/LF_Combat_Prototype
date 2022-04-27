using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeHit : MeleeHit
{
    PlayerData _playerData;

    protected override void FetchRequiredComponents()
    {
        _playerData = GetComponentInParent<PlayerData>();
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        // Target can only be hit once by the same hitbox
        if (targetsHit.Contains(col.gameObject)) return;

        targetsHit.Add(col.gameObject);

        // Gather target components
        EnemyDamageManager damageManager = col.GetComponent<EnemyDamageManager>();
        Rigidbody2D colliderRB = col.GetComponent<Rigidbody2D>();

        // Failsafe in case components are not present
        if (!damageManager || !colliderRB) return;

        screenEffectHandler.MeleeHit();

        Vector2 knockbackForce = meleeData.GetKnockbackForces();

        // Make horizontal knockback relative to player direction
        knockbackForce.x *= _playerData.transform.localScale.x;
        
        damageManager.Launch();
        colliderRB.velocity = knockbackForce;
    }
}
