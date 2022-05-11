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

    // Register horizontal input for movement and input specific actions (e.g. direction based melee attacks)
    public void RegisterHorizontalInput(float direction)
    {
        horizontalInput = direction;
    }

    // Register vertical input for movement and input specific actions (e.g. direction based melee attacks)
    public void RegisterVerticalInput(float direction)
    {
        verticalInput = direction;
    }

    // Unused by player state
    public float GetMeleeProximity()
    {
        return 0;
    }

    #endregion

    #region Virtual Methods

    public virtual void Enter()
    {
        // Subscribe to animation transmitter events
        playerData.AnimationTransmitter.OnAnimationEnd += AnimationEndEvent;
        playerData.AnimationTransmitter.OnVelocityAdded += AddVelocity;

        // Set state specific animationBool to true in animator
        playerData.Animator.SetBool(animationBool, true);

        // Perform check to determine if player is moving forward by checking if horizontal velocity is equal to current direction being faced towards
        isMovingForward = Mathf.Sign(playerData.RB.velocity.x) == Mathf.Sign(playerData.transform.localScale.x);

        // Reset inputs to prevent inputs from previous use of current state perfoming actions
        horizontalInput = 0;
        verticalInput = 0;

        // Perform physics checks to determine current state (e.g. grounded, jumping, falling, etc)
        // TODO refactor aforementioned states as separate state pattern?
        DoChecks();

        // Start time for debugging purposes
        startTime = Time.time;
    }

    public virtual void Exit()
    {
        // Unsubscribe from animation transmitter events to prevent multiple states listening and acting
        playerData.AnimationTransmitter.OnAnimationEnd -= AnimationEndEvent;
        playerData.AnimationTransmitter.OnVelocityAdded -= AddVelocity;

        // Set state specific animationBool to false in animator
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

    // TODO refactor to use gradual velocity increase instead of setting horizontal velocity
    // Controls horizontal movement based on horizontal direction float: h_Axis is an absolute value ranging from between -1 to 1
    protected virtual void MoveHorizontally(float h_Axis)
    {
        nextVelocity.x = playerData.MovementSpeed * h_Axis;
        nextVelocity.y = playerData.RB.velocity.y;

        playerData.RB.velocity = nextVelocity;
    }

    // Perform physics logic checks to determine what "Physics state" the player is currently in
    protected virtual void DoChecks()
    {
        // Player is considered moving when the current horizontal velocity crosses the player running treshold
        isMoving = Mathf.Abs(playerData.RB.velocity.x) > playerData.RunningTreshold;

        // Player is considered jumping/in upward motion while horizontal velocity is above 0
        isJumping = playerData.RB.velocity.y > 0;

        // Player is considered grounded while feet collider is touching ground AND simultaneously not in a jumping state
        isGrounded = playerData.FeetCollider.IsTouchingLayers(playerData.TerrainLayerMask) && !isJumping;

        // Player is considered falling while not on the ground AND simultaneously having a negative vertical velocity
        isFalling = !isGrounded && playerData.RB.velocity.y < 0;
    }

    // Method called whenever animationTransmitter's OnAddVelocity event is invoked
    // Add velocity to player
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
