using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    protected Enemy enemy;
    protected Rigidbody2D m_rb;
    protected Animator m_animator;

    protected EnemyState(Enemy enemy)
    {
        this.enemy = enemy;

        m_rb = enemy.GetMyRB();
        m_animator = enemy.GetMyAnimator();
    }

    #region Virtual Methods

    public virtual void ResetAnimationVariables()
    {
        m_animator.SetBool("Hurt", false);
    }

    #endregion

    #region Abstract Methods

    public abstract void ChangeAnimation();

    #endregion
}
