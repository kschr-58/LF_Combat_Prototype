using UnityEngine;

[CreateAssetMenu(fileName = "Effect Library", menuName = "Data/Effect Library", order = 1)]
public class EffectLibrary : ScriptableObject
{
    [SerializeField] public GameObject HitEffect;
    [SerializeField] public GameObject DownHitEffect;
    [SerializeField] public GameObject BigHitEffect;
}
