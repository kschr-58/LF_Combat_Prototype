using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStateManager : MonoBehaviour
{
    #region Fields
    [SerializeField] EnemyData _enemyData;
    [SerializeField] Text _stateText;

    // States
    public EnemyIdleState _idleState;
    public EnemyHurtLaunchState _launchState;

    public EnemyState CurrentState {get; private set;}

    #endregion

    #region Unity Callback Methods

    private void Awake()
    {
        InitializeStates();
    }

    private void Start()
    {
        CurrentState = _idleState;
        CurrentState.Enter();
    }

    private void Update()
    {
        CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
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

    #region Private Methods

    private void InitializeStates()
    {
        _idleState = new EnemyIdleState(_enemyData);
        _launchState = new EnemyHurtLaunchState(_enemyData);
    }

    #endregion
}
