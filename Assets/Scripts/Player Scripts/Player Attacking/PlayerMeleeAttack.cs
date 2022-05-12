using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MeleeAttack
{

    protected override void DamageTarget(CharacterData targetData)
    {
        // Damage target
        targetData.DamageSystem.DealDamage(meleeData.Damage);

        // Notify combo manager
        ComboManager.s_instance.OnComboHit(targetData.transform);
    }
}
