using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
PlayerData script is responsible for storing player related values and components
Child components access these stored values and components with getters and setters
*/
public class PlayerData : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] internal Rigidbody2D RB;
    [SerializeField] internal BoxCollider2D FeetCollider;
    [SerializeField] internal PlayerJumping JumpingComponent;
    [SerializeField] internal PlayerDodging DodgingComponent;
    [SerializeField] internal DodgeTrail DodgeTrailComponent;
    [SerializeField] internal Animator Animator;
    [SerializeField] internal Arms ArmsComponent;
    [SerializeField] internal Gun Gun;
    [SerializeField] internal Crosshair Crosshair;
    [SerializeField] internal PlayerStateManager StateManager;
    [SerializeField] internal AnimationTransmitter AnimationTransmitter;
    [SerializeField] internal LayerMask TerrainLayerMask;

    [Header("Movement Properties")]
    [SerializeField] internal float RunSpeed;
    [SerializeField] internal float JumpVelocity;
    [SerializeField] internal float ShortHopModifier;
    [SerializeField] internal float FlipVelocityTreshold;
    [SerializeField] internal float RunningTreshold;

    [Header("Dodging Properties")]
    [SerializeField] internal int MaxDodgeCount;
    [SerializeField] internal float DodgeRegenTime;
    [SerializeField] internal float RunningDodgeTime;
    [SerializeField] internal float RunningDodgeSpeed;
    [SerializeField] internal float StandingDodgeTime;
    [SerializeField] internal float AerialDodgeTime;
    [SerializeField] internal float AerialDodgeSpeed;

    [Header("Shooting Properties")]
    [SerializeField] internal float AimDuration;

    [Header("Melee Properties")]
    [SerializeField] internal Vector2 UppercutVelocity;
    [SerializeField] internal Vector2 AerialKickVelocity;
    [SerializeField] internal Vector2 StandingKickVelocity;

    #region Getters & Setters

    public PlayerState GetCurrentState()
    {
        return StateManager.CurrentState;
    }

    #endregion
}
