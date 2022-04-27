using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Melee Data", menuName = "Data/Melee Data", order = 1)]
public class MeleeData: ScriptableObject
{
    [SerializeField] Vector2 _knockbackForces;

    public Vector2 GetKnockbackForces()
    {
        return _knockbackForces;
    }
}
