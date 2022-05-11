using UnityEngine;

public abstract class PlayerState: CharacterState
{   
    // Components
    protected PlayerData playerData;
    protected PlayerStateManager stateManager;

    // Other Fields
    public string stateName {get; protected set;}
    protected Vector2 nextVelocity;
    protected float startTime;
    protected float horizontalInput;
    protected float verticalInput;
    protected string animationBool;
    protected bool isMoving;
    protected bool isJumping;
    protected bool isFalling;
    protected bool isGrounded;
    protected bool isMovingForward;

    protected PlayerState(PlayerData playerData)
    {
        this.playerData = playerData;
        this.stateManager = playerData.GetComponent<PlayerStateManager>();
    }

    #region Override Implementations

    public void RegisterHorizontalInput(float direction)
    {
        horizontalInput = direction;
    }

    public void RegisterVerticalInput(float direction)
    {
        verticalInput = direction;
    }

    public float GetMeleeProximity()
    {
        return 0;
    }

    #endregion

    #region Virtual Methods

    public virtual void Enter()
    {
        playerData.AnimationTransmitter.OnAnimationEnd += AnimationEndEvent;
        playerData.AnimationTransmitter.OnVelocityAdded += AddVelocity;
        playerData.Animator.SetBool(animationBool, true);

        isMovingForward = Mathf.Sign(playerData.RB.velocity.x) == Mathf.Sign(playerData.transform.localScale.x);

        horizontalInput = 0;
        verticalInput = 0;

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
        MoveHorizontally(horizontalInput);
    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void Launch()
    {
        return;
    }

    public virtual void ForwardLaunch()
    {
        return;
    }

    public virtual void StraightForwardLaunch()
    {
        return;
    }

    public virtual void Spike()
    {
        return;
    }

    public virtual void LightHurt()
    {
        return;
    }

    public virtual string GetStateName()
    {
        return this.stateName;
    }

    protected virtual void MoveHorizontally(float h_Axis)
    {
        nextVelocity.x = playerData.MovementSpeed * h_Axis;
        nextVelocity.y = playerData.RB.velocity.y;

        playerData.RB.velocity = nextVelocity;
    }

    protected virtual void DoChecks()
    {
        isMoving = Mathf.Abs(playerData.RB.velocity.x) > playerData.RunningTreshold;
        isGrounded = playerData.FeetCollider.IsTouchingLayers(playerData.TerrainLayerMask);
        isJumping = playerData.RB.velocity.y > 0 && !isGrounded;
        isFalling = playerData.RB.velocity.y < 0 && !isGrounded;
    }

    protected virtual void AddVelocity(Vector2 velocity)
    {
        nextVelocity.x = velocity.x * playerData.transform.localScale.x;
        nextVelocity.y = velocity.y;

        playerData.RB.velocity = nextVelocity;
    }
    
    #endregion

    #region Abstract Methods

    public abstract void Jump();

    public abstract void EndJump();

    public abstract void Dodge();

    public abstract void Melee();

    public abstract bool CanFlip();

    protected abstract void AnimationEndEvent();

    #endregion
}
