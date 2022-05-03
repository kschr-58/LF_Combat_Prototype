using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : CharacterData
{
    [Header("Enemy Components")]
    [SerializeField] internal BoxCollider2D SidesCollider;
    [SerializeField] internal SmokeTrail SmokeTrail;

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
