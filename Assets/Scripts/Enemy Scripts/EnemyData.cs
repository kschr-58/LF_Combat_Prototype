using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : CharacterData
{
    [Header("Components")]
    [SerializeField] internal EnemyStateManager StateManager;

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
