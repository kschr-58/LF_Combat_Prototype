using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    // Components
    protected EnemyData enemyData;
    protected EnemyStateManager stateManager;

    protected bool isFalling;
    protected bool isGrounded;
    
    // Other Fields
    public string stateName {get; protected set;}
    protected string animationBool;

    protected EnemyState(EnemyData enemyData)
    {
        this.enemyData = enemyData;
        this.stateManager = enemyData.StateManager;
    }

    #region Base Logic Methods

    public virtual void Enter()
    {
        enemyData.AnimationTransmitter.OnAnimationEnd += AnimationEndEvent;
        enemyData.Animator.SetBool(animationBool, true);

        DoChecks();
    }

    public virtual void Exit()
    {
        enemyData.AnimationTransmitter.OnAnimationEnd -= AnimationEndEvent;
        enemyData.Animator.SetBool(animationBool, false);
    }

    public virtual void LogicUpdate() {}

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    protected virtual void DoChecks()
    {
        isGrounded = enemyData.FeetCollider.IsTouchingLayers(enemyData.TerrainLayer);
        isFalling = enemyData.RB.velocity.y < 0 && !isGrounded;
    }

    #endregion

    #region Virtual Methods

    public virtual void Launch()
    {
        stateManager.ChangeState(stateManager._launchState);
    }

    #endregion

    #region Abstract Methods
    protected abstract void AnimationEndEvent();

    #endregion
}
