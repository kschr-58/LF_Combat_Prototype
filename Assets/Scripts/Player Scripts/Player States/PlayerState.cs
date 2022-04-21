using UnityEngine;

public abstract class PlayerState
{   
    protected Player player;
    protected Rigidbody2D m_rB;
    protected Animator m_animator;
    protected PlayerJumping m_jumpingComponent;
    protected PlayerDodging m_dodgingComponent;

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

        runSpeed = player.GetRunSpeed();
    }

    public virtual string GetStateName()
    {
        return stateName;
    }

    public virtual void ResetAnimationVariables()
    {
        m_animator.SetBool("Running", false);
        m_animator.SetBool("Dodging", false);
        m_animator.SetBool("Moving Backwards", false);
    }

    public abstract void ChangeAnimation();

    public abstract void MoveHorizontally(float h_Axis);

    public abstract void Jump();

    public abstract void Dodge();

    public abstract void EndJump();

    public abstract bool CanFlip();
}
