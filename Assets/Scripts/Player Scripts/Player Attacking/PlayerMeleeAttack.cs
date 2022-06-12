using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MeleeAttack
{

    protected override void DamageTarget(CharacterData targetData)
    {
        // Notify combo manager
        ComboManager.s_instance.OnComboHit(targetData.transform);
    }
}
