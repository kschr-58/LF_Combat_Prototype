using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateManager : StateManager
{
    #region Fields
    
    [SerializeField] PlayerData _playerData;
    [SerializeField] Text _stateText; //TODO remove

    // Grounded states
    public PlayerIdleState _idleState;
    public PlayerRunningState _runningState;
    public PlayerLandingState _landingState;

    // Aerial states
    public PlayerJumpingState _jumpingState;
    public PlayerFallingState _fallingState;

    // Dodge states
    public PlayerStandingDodgeState _standingDodgeState;
    public PlayerRunningDodgeState _runningDodgeState;
    public PlayerAerialDodgeState _aerialDodgeState;

    // Melee states
    public PlayerUppercutState _uppercutState;
    public PlayerAirKickState _aerialKickState;
    public PlayerStandingKickState _standingKickState;
    public PlayerSwipeState _swipeState;
    public PlayerSpikeState _spikeState;
    public PlayerSpinkickState _spinkickState;

    // Execution states
    public GroundedExecutionState _groundedExecutionState;

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

    #region Protected Methods

    protected override void InitializeStates()
    {
        _idleState = new PlayerIdleState(_playerData);
        _runningState = new PlayerRunningState(_playerData);
        _landingState = new PlayerLandingState(_playerData);
        
        _jumpingState = new PlayerJumpingState(_playerData);
        _fallingState = new PlayerFallingState(_playerData);

        _standingDodgeState = new PlayerStandingDodgeState(_playerData);
        _runningDodgeState = new PlayerRunningDodgeState(_playerData);
        _aerialDodgeState = new PlayerAerialDodgeState(_playerData);

        _uppercutState = new PlayerUppercutState(_playerData);
        _aerialKickState = new PlayerAirKickState(_playerData);
        _standingKickState = new PlayerStandingKickState(_playerData);
        _swipeState = new PlayerSwipeState(_playerData);
        _spikeState = new PlayerSpikeState(_playerData);
        _spinkickState = new PlayerSpinkickState(_playerData);

        _groundedExecutionState = new GroundedExecutionState(_playerData);
    }

    #endregion
}
