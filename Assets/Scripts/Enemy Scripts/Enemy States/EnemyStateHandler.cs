using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateHandler : MonoBehaviour
{
    [SerializeField] Enemy enemy;

    EnemyState currentState;
    EnemyIdleState idleState;

    #region Private Methods

    private void Start()
    {
        InitializeStates();
    }

    private void InitializeStates()
    {
        this.idleState = new EnemyIdleState(enemy);
    }

    private void ChangeState(EnemyState newState)
    {
        currentState = newState;

        enemy.SetCurrentState(newState);

        currentState.ResetAnimationVariables();
        currentState.ChangeAnimation();
    }

    #endregion
}
