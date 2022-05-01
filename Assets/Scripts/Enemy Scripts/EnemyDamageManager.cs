using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageManager : DamageManager
{
    [SerializeField] EnemyData _enemyData;

    public override void Launch()
    {
        _enemyData.GetCurrentState().Launch();
        screenEffectHandler.InstantiateVFX(_enemyData.EffectLibrary.HitEffect, _enemyData.transform.position, Quaternion.identity, _enemyData.transform.localScale);
        MainCamera.Singleton.CameraShake(3, 0.2f);
    }

    public override void ForwardLaunch()
    {
        _enemyData.GetCurrentState().ForwardLaunch();
        screenEffectHandler.InstantiateVFX(_enemyData.EffectLibrary.BigHitEffect, _enemyData.transform.position, Quaternion.identity, _enemyData.transform.localScale);
        MainCamera.Singleton.CameraShake(2, 0.25f);
    }

    public override void StraightForwardLaunch()
    {
        _enemyData.GetCurrentState().StraightForwardLaunch();
        screenEffectHandler.InstantiateVFX(_enemyData.EffectLibrary.BigHitEffect, _enemyData.transform.position, Quaternion.identity, _enemyData.transform.localScale);
        MainCamera.Singleton.CameraShake(2, 0.25f);
    }
}
