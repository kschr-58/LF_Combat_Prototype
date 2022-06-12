using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
PlayerData script is responsible for storing player related values and components
Child components access these stored values and components with getters and setters
*/
public class PlayerData : CharacterData
{
    [Header("Player Components")]
    [SerializeField] internal PlayerJumping JumpingComponent;
    [SerializeField] internal PlayerDodging DodgingComponent;
    [SerializeField] internal DodgeTrail DodgeTrailComponent;
    [SerializeField] internal Arms ArmsComponent;
    [SerializeField] internal Gun Gun;
    [SerializeField] internal Crosshair Crosshair;
    [SerializeField] internal SmokeTrail SmokeTrail;
    [SerializeField] internal InteractionSensor InteractionSensor;
    [SerializeField] internal Transform CinematicPoint;

    [Header("Player Movement Properties")]
    [SerializeField] internal float ShortHopModifier;

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
    [SerializeField] internal Vector2 SwipeVelocity;
    [SerializeField] internal Vector2 SpikeVelocity;
    [SerializeField] internal Vector2 SpinkickVelocity;

    [Header("Interaction Properties")]
    [SerializeField] internal LayerMask InteractionLayerMask;
    [SerializeField] internal float InteractionRadius;

    [Header("Debugging")]
    [SerializeField] private Text _velocityText;

    private void Update()
    {
        _velocityText.text = $"Velocity: {RB.velocity.x.ToString()}";
    }

}
