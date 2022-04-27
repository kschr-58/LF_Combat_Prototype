using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    [Header("Members")]
    [SerializeField] internal Rigidbody2D RB;
    [SerializeField] internal Animator Animator;
    [SerializeField] internal EnemyStateManager StateManager;
    [SerializeField] internal BoxCollider2D FeetCollider;
    [SerializeField] internal LayerMask TerrainLayer;
    [SerializeField] internal AnimationTransmitter AnimationTransmitter;

    [Header("Damage properties")]
    [SerializeField] internal float DefaultGravity;
    [SerializeField] internal float LaunchGravity;

    #region Getters & Setters

    public EnemyState GetCurrentState()
    {
        return StateManager.CurrentState;
    }

    #endregion

    private void Update() //TODO remove
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.position = new Vector3(0, 0, -1);
        }
    }
}
