using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Members")]
    [SerializeField] EnemyStateHandler m_stateHandler;
    [SerializeField] Rigidbody2D m_rb;
    [SerializeField] Animator m_animator;

    [Header("Damage properties")]
    [SerializeField] float defaultGravity;
    [SerializeField] float launchGravity;

    EnemyState currentState;

    #region Private Methods

    private void Start()
    {
        m_rb.gravityScale = defaultGravity;
    }

    #endregion

    #region Getters & Setters

    public EnemyState GetCurrentState()
    {
        return currentState;
    }

    public Rigidbody2D GetMyRB()
    {
        return m_rb;
    }

    public Animator GetMyAnimator()
    {
        return m_animator;
    }

    public float GetDefaultGravity()
    {
        return defaultGravity;
    }

    public float GetLaunchGravity()
    {
        return launchGravity;
    }

    public void SetCurrentState(EnemyState newState)
    {
        this.currentState = newState;
    }

    #endregion
}
