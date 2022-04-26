using UnityEngine;

public abstract class PlayerState
{   
    // Components
    protected PlayerData playerData;
    protected PlayerStateManager stateManager;

    // Other Fields
    public string stateName {get; protected set;}
    protected Vector2 nextVelocity;
    protected float startTime;
    protected string animationBool;
    protected bool isJumping;
    protected bool isFalling;
    protected bool isGrounded;
    protected bool isMovingForward;

    protected PlayerState(PlayerData playerData)
    {
        this.playerData = playerData;
        this.stateManager = playerData.StateManager;
    }

    #region Virtual Methods

    public virtual void Enter()
    {
        playerData.AnimationTransmitter.OnAnimationEnd += AnimationEndEvent;
        playerData.Animator.SetBool(animationBool, true);

        DoChecks();
        startTime = Time.time;
    }

    public virtual void Exit()
    {
        playerData.AnimationTransmitter.OnAnimationEnd -= AnimationEndEvent;
        playerData.Animator.SetBool(animationBool, false);
    }

    public virtual void LogicUpdate() 
    {
        // isGrounded = playerData.FeetCollider.IsTouchingLayers(playerData.TerrainLayerMask);
        // isJumping = playerData.RB.velocity.y > 0 && !isGrounded;
        // isFalling = playerData.RB.velocity.y < 0 && !isGrounded;
    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public void DoChecks()
    {
        isGrounded = playerData.FeetCollider.IsTouchingLayers(playerData.TerrainLayerMask);
        isJumping = playerData.RB.velocity.y > 0 && !isGrounded;
        isFalling = playerData.RB.velocity.y < 0 && !isGrounded;
    }

    #endregion

    #region Abstract Methods

    public abstract void MoveHorizontally(float h_Axis);

    public abstract void Jump();

    public abstract void EndJump();

    public abstract void Dodge();

    public abstract void Melee();

    public abstract bool CanFlip();

    protected abstract void AnimationEndEvent();

    #endregion
}
