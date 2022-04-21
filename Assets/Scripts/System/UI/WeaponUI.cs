using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponUI: MonoBehaviour
{
    public abstract void Fire();

    public abstract void LoadNextRound();
}
