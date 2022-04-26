using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateManager : MonoBehaviour
{
    #region Fields
    [SerializeField] PlayerData _playerData;
    [SerializeField] Text _stateText; //TODO remove

    // States
    public PlayerIdleState _idleState;
    public PlayerRunningState _runningState;
    public PlayerJumpingState _jumpingState;
    public PlayerFallingState _fallingState;
    public PlayerLandingState _landingState;
    public PlayerStandingDodgeState _standingDodgeState;
    public PlayerRunningDodgeState _runningDodgeState;
    public PlayerAerialDodgeState _aerialDodgeState;
    public PlayerState CurrentState {get; private set;}

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

    public void ChangeState(PlayerState newState)
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
        _idleState = new PlayerIdleState(_playerData);
        _runningState = new PlayerRunningState(_playerData);
        _jumpingState = new PlayerJumpingState(_playerData);
        _fallingState = new PlayerFallingState(_playerData);
        _landingState = new PlayerLandingState(_playerData);
        _standingDodgeState = new PlayerStandingDodgeState(_playerData);
        _runningDodgeState = new PlayerRunningDodgeState(_playerData);
        _aerialDodgeState = new PlayerAerialDodgeState(_playerData);
    }

    #endregion
}
