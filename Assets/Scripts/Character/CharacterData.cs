using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterData : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] internal Rigidbody2D RB;
    [SerializeField] internal StateManager StateManager;
    [SerializeField] internal Animator Animator;
    [SerializeField] internal BoxCollider2D FeetCollider;
    [SerializeField] internal LayerMask TerrainLayerMask;
    [SerializeField] internal EffectLibrary EffectLibrary;
    [SerializeField] internal AnimationTransmitter AnimationTransmitter;
    [SerializeField] internal CharacterFlipper CharacterFlipper;

    [Header("General Movement Properties")]
    [SerializeField] internal float MovementSpeed;
    [SerializeField] internal float JumpVelocity;
    [SerializeField] internal float RunningTreshold;
    [SerializeField] internal float FlipVelocityTreshold;

    #region Getters & Setters

    public CharacterState GetCurrentState()
    {
        return StateManager.CurrentState;
    }

    #endregion
}
