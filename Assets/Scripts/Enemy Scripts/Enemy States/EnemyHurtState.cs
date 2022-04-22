using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyHurtState : EnemyState
{
    protected EnemyHurtState(Enemy enemy) : base(enemy)
    {
        ChangeGravity();
    }

    #region Override Methods

    public override void ChangeAnimation()
    {
        m_animator.SetBool("Hurt", true);
    }

    #endregion

    #region Abstract Methods

    protected abstract void ChangeGravity();

    #endregion
}
