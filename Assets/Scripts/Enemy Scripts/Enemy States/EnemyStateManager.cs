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
    public EnemyRunningState _runningState;
    public EnemyHurtLaunchState _launchState;
    public EnemyHurtForwardLaunchState _forwardLaunchState;
    public EnemyHurtDragState _dragState;
    public EnemyHurtWallsplatState _wallsplatState;
    public EnemyHurtWallslumpState _wallslumpState;
    public EnemyHurtTumbleState _tumbleState;
    public EnemyHurtShotState _shotState;
    public EnemyRecoverLightState _recoverLightState;
    public EnemyRecoverDragState _recoverDragState;
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
        
        _launchState = new EnemyHurtLaunchState(_enemyData);
        _forwardLaunchState = new EnemyHurtForwardLaunchState(_enemyData);
        _dragState = new EnemyHurtDragState(_enemyData);
        _wallsplatState = new EnemyHurtWallsplatState(_enemyData);
        _wallslumpState = new EnemyHurtWallslumpState(_enemyData);
        _tumbleState = new EnemyHurtTumbleState(_enemyData);
        _shotState = new EnemyHurtShotState(_enemyData);

        _recoverLightState = new EnemyRecoverLightState(_enemyData);
        _recoverDragState = new EnemyRecoverDragState(_enemyData);

        _dashAttackWindupState = new EnemyDashAttackWindupState(_enemyData);
        _quickAttackWindupState = new EnemyQuickAttackWindupState(_enemyData);
        _quickAttackFollowup1WindupState = new EnemyQuickAttackFollowup1WindupState(_enemyData);

        _dashAttackState = new EnemyDashAttackState(_enemyData);
        _quickAttackState = new EnemyQuickAttackState(_enemyData);
        _quickAttackFollowup1State = new EnemyQuickAttackFollowup1State(_enemyData);
    }
}
