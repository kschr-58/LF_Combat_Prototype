using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HurtManager : MonoBehaviour
{
    [SerializeField] protected CharacterData characterData;
    
    protected ScreenEffectHandler screenEffectHandler;

    private void Start()
    {
        screenEffectHandler = ScreenEffectHandler.Instance;
    }

    #region Virtual Methods

    public virtual void FaceAggresor(int direction)
    {
        Vector3 newScale = characterData.transform.localScale;

        newScale.x = -direction;

        characterData.transform.localScale = newScale;
    }

    public virtual void ForwardLaunch()
    {
        characterData.GetCurrentState().ForwardLaunch();

        // VFX
        InstantiateVFX(characterData.EffectLibrary.BigHitEffect);
        InstantiateVFX(characterData.EffectLibrary.MeleeSparksEffect);

        CameraController.Instance.ShakeScreen(0.2f);
    }

    public virtual void Launch()
    {
        characterData.GetCurrentState().Launch();

        // VFX
        InstantiateVFX(characterData.EffectLibrary.HitEffect);
        InstantiateVFX(characterData.EffectLibrary.MeleeSparksEffect);

        CameraController.Instance.ShakeScreen(0.2f);
    }

    public virtual void LightHurt()
    {
        characterData.GetCurrentState().LightHurt();
        
        // VFX
        InstantiateVFX(characterData.EffectLibrary.MeleeSparksEffect);

        CameraController.Instance.ShakeScreen(0.2f);
    }

    public virtual void Spike()
    {
        characterData.GetCurrentState().Spike();

        // VFX
        InstantiateVFX(characterData.EffectLibrary.DownHitEffect);
        InstantiateVFX(characterData.EffectLibrary.MeleeSparksEffect);

        CameraController.Instance.ShakeScreen(2, 1, 0.2f);
    }

    public virtual void StraightForwardLaunch()
    {
        characterData.GetCurrentState().StraightForwardLaunch();

        // VFX
        InstantiateVFX(characterData.EffectLibrary.BigHitEffect);
        InstantiateVFX(characterData.EffectLibrary.MeleeSparksEffect);

        CameraController.Instance.ShakeScreen(0.2f);
    }

    public virtual void GutHurt()
    {
        characterData.GetCurrentState().GutHurt();
        
        // VFX
        InstantiateVFX(characterData.EffectLibrary.HitEffect);
        InstantiateVFX(characterData.EffectLibrary.MeleeSparksEffect);

        CameraController.Instance.ShakeScreen(0.2f);
    }

    public virtual void GroundedExecution()
    {
        characterData.GetCurrentState().GroundedExecution();

        // VFX
        InstantiateVFX(characterData.EffectLibrary.BigHitEffect);
        InstantiateVFX(characterData.EffectLibrary.MeleeSparksEffect);

        CameraController.Instance.ShakeScreen(1, 1, 0.5f);
    }

    protected virtual void InstantiateVFX(GameObject prefab)
    {
        screenEffectHandler.InstantiateVFX(prefab, characterData.transform.position, transform.rotation, characterData.transform.localScale);
    }

    #endregion
}
