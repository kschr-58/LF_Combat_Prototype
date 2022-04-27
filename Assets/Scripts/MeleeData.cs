using UnityEngine;

[CreateAssetMenu(fileName = "Melee Data", menuName = "Data/Melee Data", order = 1)]
public class MeleeData: ScriptableObject
{
    [SerializeField] public Vector2 KnockBackForce;
    [SerializeField] public AttackTypes KnockBackType;
}
