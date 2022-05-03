using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState: CharacterState
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
        this.stateManager = enemyData.GetComponent<EnemyStateManager>();
    }

    #region Override Implementations

    public void MoveHorizontally(float direction)
    {
        return;
    }

    public void MoveVertically(float direction)
    {
        return;
    }

    public void Jump()
    {
        return;
    }

    public void EndJump()
    {
        return;
    }

    public void Dodge()
    {
        return;
    }

    public void Melee()
    {
        return;
    }

    public virtual string GetStateName()
    {
        return this.stateName;
    }

    public virtual bool CanFlip()
    {
        return false;
    }

    #endregion

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
        isGrounded = enemyData.FeetCollider.IsTouchingLayers(enemyData.TerrainLayerMask);
        isFalling = enemyData.RB.velocity.y < 0 && !isGrounded;
    }

    #endregion

    #region Virtual Methods

    public virtual void Launch()
    {
        stateManager.ChangeState(stateManager._launchState);
    }

    public virtual void ForwardLaunch()
    {
        stateManager.ChangeState(stateManager._forwardLaunchState);
    }

    public virtual void StraightForwardLaunch()
    {
        if (isGrounded) stateManager.ChangeState(stateManager._dragState);
        else stateManager.ChangeState(stateManager._forwardLaunchState);
    }

    public virtual void Shot()
    {
        stateManager.ChangeState(stateManager._shotState);
    }

    #endregion

    #region Abstract Methods

    protected abstract void AnimationEndEvent();

    #endregion
}
