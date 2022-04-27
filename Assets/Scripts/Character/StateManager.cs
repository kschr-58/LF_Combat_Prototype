using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateManager : MonoBehaviour
{
    CharacterState CurrentState;

    #region Unity Callback Methods

    protected virtual void Awake()
    {
        InitializeStates();
    }

    protected virtual void Update()
    {
        CurrentState.LogicUpdate();
    }

    protected virtual void FixedUpdate()
    {
        CurrentState.PhysicsUpdate();
    }

    #endregion

    #region Virtual Methods

    public void ChangeState(CharacterState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }

    #endregion

    #region Abstract Methods

    protected abstract void InitializeStates();

    #endregion
}
