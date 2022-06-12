using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : CharacterData
{
    [Header("Enemy Components")]
    [SerializeField] internal TargetDetection TargetDetectionComponent;
    [SerializeField] internal TargetChasing TargetChasingComponent;
    [SerializeField] internal EnemyMeleeLogic EnemyMeleeLogicComponent;
    [SerializeField] internal BoxCollider2D SidesCollider;
    [SerializeField] internal SmokeTrail SmokeTrail;
    [SerializeField] internal Collider2D ExecutionProximityCollider;

    [Header("Detection Properties")]
    [SerializeField] internal LayerMask TargetLayers;
    [SerializeField] internal LayerMask ObstructionLayers;
    [SerializeField] internal LayerMask TerrainLayers;
    [SerializeField] internal float DetectionRadius;

    [Header("Chasing properties")]
    [SerializeField] internal float DesiredProximity;

    [Header("State Gravity properties")]
    [SerializeField] internal float DefaultGravity;
    [SerializeField] internal float ShotGravity;
    [SerializeField] internal float LaunchGravity;
    [SerializeField] internal float WallSplatGravity;
    [SerializeField] internal float GroundBounceGravity;

    [Header("State velocity properties")]
    [SerializeField] internal Vector2 GroundBounceVelocity;

    [Header("Melee velocity properties")]
    [SerializeField] internal Vector2 DashAttackVelocity;
    [SerializeField] internal Vector2 QuickAttackVelocity;
    [SerializeField] internal Vector2 QuickAttackFollowup1Velocity;

    [Header("Melee logic properties")]
    [SerializeField] internal float MeleeAttackDelay;
    [SerializeField] internal float RunningMeleeProximity;
    [SerializeField] internal float StandingMeleeProximity;
    [SerializeField] [Range(0, 100)] internal float followupChance;

    private void Update() //TODO remove
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.position = new Vector3(0, 0, -1);
        }
    }
}
