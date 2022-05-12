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
    [SerializeField] internal HurtManager HurtManager;
    [SerializeField] internal DamageSystem DamageSystem;

    [Header("General Movement Properties")]
    [SerializeField] internal float MovementSpeed;
    [SerializeField] internal float JumpVelocity;
    [SerializeField] internal float RunningTreshold;
    [SerializeField] internal float FlipVelocityTreshold;

    [Header("Damage properties")]
    [Tooltip("Damage treshold before entering kill state")]
    [SerializeField] internal float MaxDamage;
    [Tooltip("Regen timer set to the following number upon being hit")]
    [SerializeField] internal float DamageRegenDelay;
    [Tooltip("Rate at which damage regenerates once the regen timer reaches 0")]
    [SerializeField] internal float DamageRegenRate;
    [SerializeField] internal float KillStateDuration;
    [Tooltip("Amount of damage recovered after recovering from kill state")]
    [SerializeField] internal float KillStateDamageRecovery;

    #region Getters & Setters

    public CharacterState GetCurrentState()
    {
        return StateManager.CurrentState;
    }

    #endregion
}
