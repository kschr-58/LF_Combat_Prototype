using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageManager : DamageManager
{
    public override void Launch()
    {
        characterData.GetCurrentState().Launch();

        // VFX
        InstantiateVFX(characterData.EffectLibrary.HitEffect);
        InstantiateVFX(characterData.EffectLibrary.MeleeSparksEffect);

        MainCamera.Singleton.CameraShake(3, 0.2f);
    }

    public override void ForwardLaunch()
    {
        characterData.GetCurrentState().ForwardLaunch();

        // VFX
        InstantiateVFX(characterData.EffectLibrary.BigHitEffect);
        InstantiateVFX(characterData.EffectLibrary.MeleeSparksEffect);

        MainCamera.Singleton.CameraShake(2, 0.25f);
    }

    public override void StraightForwardLaunch()
    {
        characterData.GetCurrentState().StraightForwardLaunch();

        // VFX
        InstantiateVFX(characterData.EffectLibrary.BigHitEffect);
        InstantiateVFX(characterData.EffectLibrary.MeleeSparksEffect);
        MainCamera.Singleton.CameraShake(2, 0.25f);
    }

    public override void Spike()
    {
        characterData.GetCurrentState().Spike();

        // VFX
        InstantiateVFX(characterData.EffectLibrary.DownHitEffect);
        InstantiateVFX(characterData.EffectLibrary.MeleeSparksEffect);
        MainCamera.Singleton.CameraShake(3, 0.2f);
    }

    public override void Shot()
    {
        characterData.GetCurrentState().Shot();
        
        InstantiateVFX(characterData.EffectLibrary.MeleeSparksEffect);
        
        MainCamera.Singleton.CameraShake(1, 0.1f);
    }

    private void InstantiateVFX(GameObject prefab)
    {
        screenEffectHandler.InstantiateVFX(prefab, characterData.transform.position, Quaternion.identity, characterData.transform.localScale);
    }
}
