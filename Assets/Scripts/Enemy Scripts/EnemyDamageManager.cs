using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageManager : DamageManager
{
    [SerializeField] EnemyData _enemyData;

    public override void Launch()
    {
        _enemyData.GetCurrentState().Launch();

        // VFX
        InstantiateVFX(_enemyData.EffectLibrary.HitEffect);
        InstantiateVFX(_enemyData.EffectLibrary.MeleeSparksEffect);

        MainCamera.Singleton.CameraShake(3, 0.2f);
    }

    public override void ForwardLaunch()
    {
        _enemyData.GetCurrentState().ForwardLaunch();

        // VFX
        InstantiateVFX(_enemyData.EffectLibrary.BigHitEffect);
        InstantiateVFX(_enemyData.EffectLibrary.MeleeSparksEffect);

        MainCamera.Singleton.CameraShake(2, 0.25f);
    }

    public override void StraightForwardLaunch()
    {
        _enemyData.GetCurrentState().StraightForwardLaunch();

        // VFX
        InstantiateVFX(_enemyData.EffectLibrary.BigHitEffect);
        InstantiateVFX(_enemyData.EffectLibrary.MeleeSparksEffect);
        MainCamera.Singleton.CameraShake(2, 0.25f);
    }

    public override void Shot()
    {
        _enemyData.GetCurrentState().Shot();
        
        InstantiateVFX(_enemyData.EffectLibrary.MeleeSparksEffect);
        
        MainCamera.Singleton.CameraShake(1, 0.1f);
    }

    private void InstantiateVFX(GameObject prefab)
    {
        screenEffectHandler.InstantiateVFX(prefab, _enemyData.transform.position, Quaternion.identity, _enemyData.transform.localScale);
    }
}
