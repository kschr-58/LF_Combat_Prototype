using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MeleeAttack
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
        DamageManager damageManager = col.GetComponent<DamageManager>();
        Rigidbody2D colliderRB = col.GetComponent<Rigidbody2D>();

        // Failsafe in case components are not present
        if (!damageManager || !colliderRB) return;

        Vector2 knockbackForce = meleeData.KnockBackForce;

        // Make horizontal knockback relative to player direction
        knockbackForce.x *= _playerData.transform.localScale.x;

        //Apply knockback
        colliderRB.velocity = knockbackForce;
        
        // Change target state
        ChangeTargetState(damageManager);

        //Make target face player
        damageManager.FaceAggresor(_playerData.transform);
    }
}
