using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Serialized fields
    [SerializeField] PlayerData _playerData;

    // Other references
    private Vector2 _directionalInput;

    #region Private Methods

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        HandleHorizontalInput();
        HandleVerticalInput();
        HandleJumpInput();
        HandleDodgeInput();
        HandleFireInput();
        HandleReloadInput();
        HandleMeleeInput();
    }

    private void HandleHorizontalInput()
    {
        _directionalInput.x = Input.GetAxisRaw("Horizontal");

        _playerData.GetCurrentState().MoveHorizontally(_directionalInput.x);
    }

    private void HandleVerticalInput()
    {
        _directionalInput.y = Input.GetAxisRaw("Vertical");
        
        _playerData.GetCurrentState().MoveVertically(_directionalInput.y);
    }

    private void HandleJumpInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _playerData.GetCurrentState().Jump();
        }

        else if (Input.GetButtonUp("Jump"))
        {
            _playerData.GetCurrentState().EndJump();
        }
    }

    private void HandleDodgeInput()
    {
        if (Input.GetButtonDown("Dodge"))
        {
            _playerData.GetCurrentState().Dodge();
        }
    }

    private void HandleFireInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _playerData.ArmsComponent.FireWeapon();
        }
    }

    private void HandleReloadInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _playerData.ArmsComponent.Reload();
        }
    }

    private void HandleMeleeInput()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            _playerData.GetCurrentState().Melee();
        }
    }

    #endregion
}
