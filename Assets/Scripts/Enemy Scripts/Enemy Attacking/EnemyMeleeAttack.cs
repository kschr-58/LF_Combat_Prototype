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
        Debug.Log("Player hit!");
    }
}
