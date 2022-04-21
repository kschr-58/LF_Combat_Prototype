using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeData: MonoBehaviour
{
    [SerializeField] Vector2 knockbackForces;

    public Vector2 GetKnockbackForces()
    {
        return knockbackForces;
    }
}
