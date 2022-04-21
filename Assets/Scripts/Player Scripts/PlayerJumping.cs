using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    [SerializeField] Player player;

    Rigidbody2D m_rB;
    Vector2 nextVelocity;
    float groundedJumpDelay = 0.1f;

    bool groundedJumpReady = true;

    #region Public Methods

    public void GroundedJump()
    {
        if (!groundedJumpReady) return;

        player.GetMyAnimator().SetTrigger("Jump");

        nextVelocity.x = 0f;
        nextVelocity.y = player.GetJumpHeight();

        m_rB.velocity += nextVelocity;

        StartCoroutine(DelayGroundedJump());
    }

    public void AerialJump()
    {
        if (!groundedJumpReady) return;

        player.GetMyAnimator().SetTrigger("Jump");

        nextVelocity.x = m_rB.velocity.x;
        nextVelocity.y = player.GetJumpHeight();

        m_rB.velocity = nextVelocity;

        StartCoroutine(DelayGroundedJump());
    }

    public void ShortHop()
    {
        // Perform jump check
        if (m_rB.velocity.y < 0) return;

        nextVelocity.x = m_rB.velocity.x;
        nextVelocity.y = m_rB.velocity.y * player.GetShortHopModifier();
        
        m_rB.velocity = nextVelocity;
    }

    #endregion

    #region Private Methods

    private void Start()
    {
        this.m_rB = player.GetMyRB();
    }

    private IEnumerator DelayGroundedJump()
    {
        groundedJumpReady = false;

        yield return new WaitForSeconds(groundedJumpDelay);

        groundedJumpReady = true;
    }

    #endregion
}
