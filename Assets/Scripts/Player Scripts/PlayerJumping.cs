using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;

    Vector2 nextVelocity;
    float groundedJumpDelay = 0.1f;

    bool groundedJumpReady = true;

    #region Public Methods

    public void GroundedJump()
    {
        if (!groundedJumpReady) return;

        nextVelocity.x = 0f;
        nextVelocity.y = _playerData.JumpVelocity;

        _playerData.RB.velocity += nextVelocity;

        // Instantiate VFX
        ScreenEffectHandler.Singleton.InstantiateVFX(_playerData.EffectLibrary.ForwardJumpEffect, _playerData.transform.position, Quaternion.identity, _playerData.transform.localScale);

        StartCoroutine(DelayGroundedJump());
    }

    public void AerialJump()
    {
        nextVelocity.x = _playerData.RB.velocity.x;
        nextVelocity.y = _playerData.JumpVelocity;

        _playerData.RB.velocity = nextVelocity;

        StartCoroutine(DelayGroundedJump());
    }

    public void ShortHop()
    {
        // Perform jump check
        if (_playerData.RB.velocity.y < 0) return;

        nextVelocity.x = _playerData.RB.velocity.x;
        nextVelocity.y = _playerData.RB.velocity.y * _playerData.ShortHopModifier;
        
        _playerData.RB.velocity = nextVelocity;
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
