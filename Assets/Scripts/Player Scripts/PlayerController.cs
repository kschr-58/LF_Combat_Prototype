using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Serialized fields
    [SerializeField] Player player;

    // Component references
    Arms m_arms;

    // Other references
    Vector2 axis;

    #region Private Methods

    private void Start()
    {
        m_arms = player.GetMyArms();
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        HandleHorizontalInput();
        HandleJumpInput();
        HandleDodgeInput();
        HandleFireInput();
        HandleReloadInput();
        HandleMeleeInput();
    }

    private void HandleHorizontalInput()
    {
        axis.x = Input.GetAxisRaw("Horizontal");

        player.GetCurrentState().MoveHorizontally(axis.x);
    }

    private void HandleVerticalInput()
    {
        axis.y = Input.GetAxisRaw("Vertical");
    }

    private void HandleJumpInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            player.GetCurrentState().Jump();
        }

        else if (Input.GetButtonUp("Jump"))
        {
            player.GetCurrentState().EndJump();
        }
    }

    private void HandleDodgeInput()
    {
        if (Input.GetButtonDown("Dodge"))
        {
            player.GetCurrentState().Dodge();
        }
    }

    private void HandleFireInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_arms.FireWeapon();
        }
    }

    private void HandleReloadInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            m_arms.Reload();
        }
    }

    private void HandleMeleeInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            player.GetCurrentState().Melee();
        }
    }

    #endregion
}
