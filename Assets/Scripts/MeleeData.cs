using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeData: MonoBehaviour
{
    [SerializeField] Vector2 _knockbackForces;

    public Vector2 GetKnockbackForces()
    {
        return _knockbackForces;
    }
}
