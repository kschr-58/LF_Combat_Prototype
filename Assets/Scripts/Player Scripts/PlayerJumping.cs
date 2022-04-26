using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    [SerializeField] PlayerData _player;

    Vector2 nextVelocity;
    float groundedJumpDelay = 0.1f;

    bool groundedJumpReady = true;

    #region Public Methods

    public void GroundedJump()
    {
        if (!groundedJumpReady) return;

        nextVelocity.x = 0f;
        nextVelocity.y = _player.JumpVelocity;

        _player.RB.velocity += nextVelocity;

        StartCoroutine(DelayGroundedJump());
    }

    public void AerialJump()
    {
        if (!groundedJumpReady) return;

        nextVelocity.x = _player.RB.velocity.x;
        nextVelocity.y = _player.JumpVelocity;

        _player.RB.velocity = nextVelocity;

        StartCoroutine(DelayGroundedJump());
    }

    public void ShortHop()
    {
        // Perform jump check
        if (_player.RB.velocity.y < 0) return;

        nextVelocity.x = _player.RB.velocity.x;
        nextVelocity.y = _player.RB.velocity.y * _player.ShortHopModifier;
        
        _player.RB.velocity = nextVelocity;
    }

    #endregion

    #region Private Methods

    private IEnumerator DelayGroundedJump()
    {
        groundedJumpReady = false;

        yield return new WaitForSeconds(groundedJumpDelay);

        groundedJumpReady = true;
    }

    #endregion
}
