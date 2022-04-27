using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStateManager : StateManager
{
    #region Fields
    [SerializeField] EnemyData _enemyData;
    [SerializeField] Text _stateText;

    // States
    public EnemyIdleState _idleState;
    public EnemyHurtLaunchState _launchState;
    public EnemyHurtForwardLaunchState _forwardLaunchState;
    public EnemyHurtDragState _dragState;

    public EnemyState CurrentState {get; private set;}

    #endregion

    #region Unity Callback Methods

    private void Start()
    {
        CurrentState = _idleState;
        CurrentState.Enter();
    }

    protected override void Update()
    {
        CurrentState.LogicUpdate();
    }

    protected override void FixedUpdate()
    {
        CurrentState.PhysicsUpdate();
    }

    #endregion

    #region Public Methods

    public void ChangeState(EnemyState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();

        _stateText.text = $"State: {CurrentState.stateName}";
    }

    #endregion
    protected override void InitializeStates()
    {
        _idleState = new EnemyIdleState(_enemyData);
        _launchState = new EnemyHurtLaunchState(_enemyData);
        _forwardLaunchState = new EnemyHurtForwardLaunchState(_enemyData);
        _dragState = new EnemyHurtDragState(_enemyData);
    }
}
