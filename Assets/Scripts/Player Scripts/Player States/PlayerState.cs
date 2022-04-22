using UnityEngine;

public abstract class PlayerState
{   
    protected Player player;
    protected Rigidbody2D m_rB;
    protected Animator m_animator;
    protected PlayerJumping m_jumpingComponent;
    protected PlayerDodging m_dodgingComponent;
    protected PlayerMelee m_meleeComponent;
    protected PlayerStateHandler m_playerStateHandler;

    protected Vector2 nextVelocity;
    protected float runSpeed;
    protected string stateName;

    protected PlayerState(Player player)
    {
        this.player = player;
        this.m_rB = player.GetMyRB();
        this.m_animator = player.GetMyAnimator();
        this.m_jumpingComponent = player.GetMyJumpingComponent();
        this.m_dodgingComponent = player.GetMyDodgingComponent();
        this.m_meleeComponent = player.GetMyMeleeComponent();
        this.m_playerStateHandler = player.GetMyStateHandler();

        runSpeed = player.GetRunSpeed();

        player.GetMyAnimationTransmitter().OnAnimationEnd += AnimationEndEvent;
    }

    #region Virtual Methods

    public virtual void InitializeState()
    {
        ResetAnimationVariables();
        ChangeAnimation();
    }

    public virtual string GetStateName()
    {
        return stateName;
    }

    protected virtual void ResetAnimationVariables()
    {
        m_animator.SetBool("Running", false);
        m_animator.SetBool("Dodging", false);
        m_animator.SetBool("Moving Backwards", false);
    }

    #endregion

    #region Abstract Methods

    protected abstract void ChangeAnimation();
    
    protected abstract void AnimationEndEvent();

    public abstract void MoveHorizontally(float h_Axis);

    public abstract void Jump();

    public abstract void Dodge();

    public abstract void EndJump();

    public abstract void Melee();

    public abstract bool CanFlip();


    #endregion
}
