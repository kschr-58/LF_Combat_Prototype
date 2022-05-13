using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStateManager : StateManager
{
    #region Fields
    [SerializeField] EnemyData _enemyData;
    [SerializeField] Text _stateText;

    // Grounded states
    public EnemyIdleState _idleState;
    public EnemyRunningState _runningState;
    // Hurt states
    public EnemyLaunchState _launchState;
    public EnemyForwardLaunchState _forwardLaunchState;
    public EnemyDragState _dragState;
    public EnemyWallsplatState _wallsplatState;
    public EnemyWallslumpState _wallslumpState;
    public EnemyTumbleState _tumbleState;
    public EnemyLightHurtState _lightHurtState;
    public EnemyGroundBounceState _groundBounceState;
    public EnemyDownwardLaunchState _downwardLaunchState;
    public EnemyKnockdownState _knockdownState;
    // Recover states
    public EnemyLightRecoveryState _lightRecoveryState;
    public EnemyDragRecoveryState _dragRecoveryState;
    public EnemyKnockdownRecoveryState _knockdownRecoveryState;
    // Attack states
    public EnemyDashAttackWindupState _dashAttackWindupState;
    public EnemyQuickAttackWindupState _quickAttackWindupState;
    public EnemyQuickAttackFollowup1WindupState _quickAttackFollowup1WindupState;
    public EnemyDashAttackState _dashAttackState;
    public EnemyQuickAttackState _quickAttackState;
    public EnemyQuickAttackFollowup1State _quickAttackFollowup1State;

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

        _stateText.text = $"State: {CurrentState.GetStateName()}";
    }

    #endregion
    protected override void InitializeStates()
    {
        _idleState = new EnemyIdleState(_enemyData);
        _runningState = new EnemyRunningState(_enemyData);
        
        _launchState = new EnemyLaunchState(_enemyData);
        _forwardLaunchState = new EnemyForwardLaunchState(_enemyData);
        _dragState = new EnemyDragState(_enemyData);
        _wallsplatState = new EnemyWallsplatState(_enemyData);
        _wallslumpState = new EnemyWallslumpState(_enemyData);
        _tumbleState = new EnemyTumbleState(_enemyData);
        _lightHurtState = new EnemyLightHurtState(_enemyData);
        _downwardLaunchState = new EnemyDownwardLaunchState(_enemyData);
        _groundBounceState = new EnemyGroundBounceState(_enemyData);
        _knockdownState = new EnemyKnockdownState(_enemyData);

        _lightRecoveryState = new EnemyLightRecoveryState(_enemyData);
        _dragRecoveryState = new EnemyDragRecoveryState(_enemyData);
        _knockdownRecoveryState = new EnemyKnockdownRecoveryState(_enemyData);

        _dashAttackWindupState = new EnemyDashAttackWindupState(_enemyData);
        _quickAttackWindupState = new EnemyQuickAttackWindupState(_enemyData);
        _quickAttackFollowup1WindupState = new EnemyQuickAttackFollowup1WindupState(_enemyData);

        _dashAttackState = new EnemyDashAttackState(_enemyData);
        _quickAttackState = new EnemyQuickAttackState(_enemyData);
        _quickAttackFollowup1State = new EnemyQuickAttackFollowup1State(_enemyData);
    }
}
