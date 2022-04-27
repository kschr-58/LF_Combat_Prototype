using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageManager : DamageManager
{
    [SerializeField] EnemyData _enemyData;

    public override void Launch()
    {
        _enemyData.GetCurrentState().Launch();
    }

    public override void ForwardLaunch()
    {
        _enemyData.GetCurrentState().ForwardLaunch();
    }

    public override void StraightForwardLaunch()
    {
        _enemyData.GetCurrentState().StraightForwardLaunch();
    }
}
