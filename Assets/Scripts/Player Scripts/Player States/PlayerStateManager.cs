using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateManager : StateManager
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
    public PlayerUppercutState _uppercutState;
    public PlayerAirKickState _aerialKickState;
    public PlayerStandingKickState _standingKickState;

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

    public void ChangeState(PlayerState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();

        _stateText.text = $"State: {CurrentState.GetStateName()}";
    }

    #endregion

    protected override void InitializeStates()
    {
        _idleState = new PlayerIdleState(_playerData);
        _runningState = new PlayerRunningState(_playerData);
        _jumpingState = new PlayerJumpingState(_playerData);
        _fallingState = new PlayerFallingState(_playerData);
        _landingState = new PlayerLandingState(_playerData);
        _standingDodgeState = new PlayerStandingDodgeState(_playerData);
        _runningDodgeState = new PlayerRunningDodgeState(_playerData);
        _aerialDodgeState = new PlayerAerialDodgeState(_playerData);
        _uppercutState = new PlayerUppercutState(_playerData);
        _aerialKickState = new PlayerAirKickState(_playerData);
        _standingKickState = new PlayerStandingKickState(_playerData);
    }
}
