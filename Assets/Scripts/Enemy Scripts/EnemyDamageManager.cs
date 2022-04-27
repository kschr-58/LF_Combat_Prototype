using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageManager : DamageManager
{
    [SerializeField] EnemyData _enemyData;

    public override void Launch()
    {
        _enemyData.GetCurrentState().Launch();
        InstantiateVFX(_enemyData.transform.position, _enemyData.EffectLibrary.HitEffect);
    }

    public override void ForwardLaunch()
    {
        _enemyData.GetCurrentState().ForwardLaunch();
        InstantiateVFX(_enemyData.transform.position, _enemyData.EffectLibrary.BigHitEffect);
    }

    public override void StraightForwardLaunch()
    {
        _enemyData.GetCurrentState().StraightForwardLaunch();
        InstantiateVFX(_enemyData.transform.position, _enemyData.EffectLibrary.BigHitEffect);
    }
}
