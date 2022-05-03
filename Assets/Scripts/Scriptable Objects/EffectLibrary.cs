using UnityEngine;

[CreateAssetMenu(fileName = "Effect Library", menuName = "Data/Effect Library", order = 1)]
public class EffectLibrary : ScriptableObject
{
    [Header("Damage VFX")]
    [SerializeField] public GameObject MeleeSparksEffect;
    [SerializeField] public GameObject HitEffect;
    [SerializeField] public GameObject DownHitEffect;
    [SerializeField] public GameObject BigHitEffect;
    [Header("Movement VFX")]
    [SerializeField] public GameObject ForwardJumpEffect;
    [SerializeField] public GameObject LandingEffect;
}
