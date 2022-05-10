using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageManager : DamageManager
{
    public override void ForwardLaunch()
    {
        // VFX
        InstantiateVFX(characterData.EffectLibrary.HitEffect);
        InstantiateVFX(characterData.EffectLibrary.MeleeSparksEffect);

        MainCamera.Singleton.CameraShake(3, 0.2f);
    }

    public override void Launch()
    {
        // VFX
        InstantiateVFX(characterData.EffectLibrary.HitEffect);
        InstantiateVFX(characterData.EffectLibrary.MeleeSparksEffect);

        MainCamera.Singleton.CameraShake(3, 0.2f);
    }

    public override void Shot()
    {
        // VFX
        InstantiateVFX(characterData.EffectLibrary.HitEffect);
        InstantiateVFX(characterData.EffectLibrary.MeleeSparksEffect);

        MainCamera.Singleton.CameraShake(3, 0.2f);
    }

    public override void Spike()
    {
        // VFX
        InstantiateVFX(characterData.EffectLibrary.HitEffect);
        InstantiateVFX(characterData.EffectLibrary.MeleeSparksEffect);

        MainCamera.Singleton.CameraShake(3, 0.2f);
    }

    public override void StraightForwardLaunch()
    {
        // VFX
        InstantiateVFX(characterData.EffectLibrary.HitEffect);
        InstantiateVFX(characterData.EffectLibrary.MeleeSparksEffect);

        MainCamera.Singleton.CameraShake(3, 0.2f);
    }

    private void InstantiateVFX(GameObject prefab)
    {
        screenEffectHandler.InstantiateVFX(prefab, characterData.transform.position, Quaternion.identity, characterData.transform.localScale);
    }
}
