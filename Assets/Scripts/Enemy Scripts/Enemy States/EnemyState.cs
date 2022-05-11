using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState: CharacterState
{
    // Components
    protected EnemyData enemyData;
    protected EnemyStateManager stateManager;

    protected Vector2 nextVelocity;
    public string stateName {get; protected set;}
    protected string animationBool;
    protected float startTime;
    protected bool isMoving;
    protected bool isJumping;
    protected bool isFalling;
    protected bool isGrounded;

    protected EnemyState(EnemyData enemyData)
    {
        this.enemyData = enemyData;
        this.stateManager = enemyData.GetComponent<EnemyStateManager>();
    }

    #region Override Implementations

    public void RegisterHorizontalInput(float direction)
    {
        return;
    }

    public void RegisterVerticalInput(float direction)
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

    #endregion

    #region Base Logic Methods

    public virtual void Enter()
    {
        // Subscribe to animation transmitter's events
        enemyData.AnimationTransmitter.OnAnimationEnd += AnimationEndEvent;

        // Set state specific animationBool to true in animator
        enemyData.Animator.SetBool(animationBool, true);

        // Perform physics checks to determine current state (e.g. grounded, jumping, falling, etc)
        DoChecks();

        // Start time for debugging purposes
        startTime = Time.time;
    }

    public virtual void Exit()
    {
        // Unsubscribe from animation transmitter events to prevent multiple states listening and acting
        enemyData.AnimationTransmitter.OnAnimationEnd -= AnimationEndEvent;

        // Set state specific animationBool to false in animator
        enemyData.Animator.SetBool(animationBool, false);
    }

    public virtual void LogicUpdate() {}

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    protected virtual void DoChecks()
    {
        // Player is considered moving when the current horizontal velocity crosses the player running treshold
        isMoving = Mathf.Abs(enemyData.RB.velocity.x) > enemyData.RunningTreshold;

        // Player is considered jumping/in upward motion while horizontal velocity is above 0
        isJumping = enemyData.RB.velocity.y > 0;

        // Player is considered grounded while feet collider is touching ground AND simultaneously not in a jumping state
        isGrounded = enemyData.FeetCollider.IsTouchingLayers(enemyData.TerrainLayerMask) && !isJumping;

        // Player is considered falling while not on the ground AND simultaneously having a negative vertical velocity
        isFalling = !isGrounded && enemyData.RB.velocity.y < 0;
    }

    #endregion

    #region Virtual Methods

    public virtual void Dodge()
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

    public virtual float GetMeleeProximity()
    {
        // Default melee proximity is set to standing melee proximity
        return enemyData.StandingMeleeProximity;
    }

    public virtual void Launch()
    {
        // Default transition to launch state
        stateManager.ChangeState(stateManager._launchState);
    }

    public virtual void ForwardLaunch()
    {
        // Default transition to forward launch state
        stateManager.ChangeState(stateManager._forwardLaunchState);
    }

    public virtual void StraightForwardLaunch()
    {
        // Transition to drag state if currently grounded
        if (isGrounded) stateManager.ChangeState(stateManager._dragState);

        // Transition to forward launch state if aerial
        else stateManager.ChangeState(stateManager._forwardLaunchState);
    }

    public virtual void Spike()
    {
        // Default transition to drag state
        stateManager.ChangeState(stateManager._dragState); // TODO to bounce state
    }

    public virtual void LightHurt()
    {
        // Default transition to shot state
        stateManager.ChangeState(stateManager._shotState);
    }

    #endregion

    #region Abstract Methods

    public abstract void Melee();

    protected abstract void AnimationEndEvent();

    #endregion
}
