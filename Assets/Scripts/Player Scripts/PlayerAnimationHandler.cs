using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    [SerializeField] PlayerData player;

    Animator m_animator;
    Rigidbody2D m_rB;
    Coroutine landingCoroutine;

    // #region Public Methods

    // #endregion

    // #region Private Methods

    // private void Awake()
    // {
    //     player.GetMyStateHandler().OnStateChange += HandleStateChange;
    // }

    // private void Start()
    // {
    //     m_animator = player.GetMyAnimator();
    //     m_rB = player.GetMyRB();
    // }

    // private void HandleStateChange(PlayerState newState)
    // {
    //     return;
    // }

    // #endregion

    // #region Coroutines

    // private IEnumerator WaitForLanding()
    // {
    //     yield return new WaitUntil(() => {
    //         return m_rB.velocity.y >= 0f;
    //     });

    //     landingCoroutine = null;
    // }

    // #endregion
}
