using UnityEngine;

[CreateAssetMenu(fileName = "Animation Velocity Data", menuName = "Data/Animation/Animation Velocity Data", order = 1)]
public class AnimationVelocityData : ScriptableObject
{
    [SerializeField] public float horizontalVelocity;
    [SerializeField] public float verticalVelocity;
}
