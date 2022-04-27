using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
PlayerData script is responsible for storing player related values and components
Child components access these stored values and components with getters and setters
*/
public class PlayerData : CharacterData
{
    [SerializeField] internal PlayerStateManager StateManager;
    [SerializeField] internal PlayerJumping JumpingComponent;
    [SerializeField] internal PlayerDodging DodgingComponent;
    [SerializeField] internal DodgeTrail DodgeTrailComponent;
    [SerializeField] internal Arms ArmsComponent;
    [SerializeField] internal Gun Gun;
    [SerializeField] internal Crosshair Crosshair;

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

    public CharacterState GetCurrentState()
    {
        return StateManager.CurrentState;
    }

    #endregion
}
