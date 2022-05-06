using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : CharacterData
{
    [Header("Enemy Components")]
    [SerializeField] internal TargetDetection TargetDetectionComponent;
    [SerializeField] internal TargetChasing TargetChasingComponent;
    [SerializeField] internal BoxCollider2D SidesCollider;
    [SerializeField] internal SmokeTrail SmokeTrail;

    [Header("Detection Properties")]
    [SerializeField] internal LayerMask TargetLayers;
    [SerializeField] internal LayerMask ObstructionLayers;
    [SerializeField] internal LayerMask TerrainLayers;
    [SerializeField] internal float DetectionRadius;

    [Header("Chasing properties")]
    [SerializeField] internal float DesiredProximity;

    [Header("Damage properties")]
    [SerializeField] internal float DefaultGravity;
    [SerializeField] internal float ShotGravity;
    [SerializeField] internal float LaunchGravity;
    [SerializeField] internal float WallSplatGravity;

    private void Update() //TODO remove
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.position = new Vector3(0, 0, -1);
        }
    }
}
