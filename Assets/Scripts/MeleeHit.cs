using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHit : MonoBehaviour
{
    List<GameObject> targetsHit = new List<GameObject>();
    MeleeData m_meleeData;

    private void Start()
    {
        m_meleeData = GetComponent<MeleeData>();
    }

    private void OnEnable()
    {
        targetsHit.Clear();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (targetsHit.Contains(col.gameObject)) return;

        targetsHit.Add(col.gameObject);

        EnemyDamageManager damageManager = col.GetComponent<EnemyDamageManager>();
        Rigidbody2D colliderRB = col.GetComponent<Rigidbody2D>();

        if (!damageManager || !colliderRB) return;

        ScreenEffectHandler.GetInstance().MeleeHit();
        
        damageManager.Launch();
        colliderRB.velocity = m_meleeData.GetKnockbackForces();
    }
}
