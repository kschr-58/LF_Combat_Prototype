using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateHandler : MonoBehaviour
{
    // Serialized Fields
    [SerializeField] Player player;
    [SerializeField] Text stateText; //TODO remove

    // Component References
    BoxCollider2D m_feetCollider;
    Rigidbody2D m_RB;
    LayerMask terrainLayerMask;
    PlayerState currentState;

    // Grounded States
    PlayerGroundedState_Idle idleState;
    PlayerGroundedState_Running runningState;
    PlayerGroundedState_Landing landingState;

    // Aerial States
    PlayerAerialState_Jumping jumpingState;
    PlayerAerialState_Upward upwardState;
    PlayerAerialState_Falling fallingState;

    // Dodging States
    PlayerDodgingState dodgingState;

    // Melee States
    PlayerMeleeState_Uppercut uppercutState;

    // Other References
    float playerRunningTreshold;
    bool isDodging = false;
    bool isPerfomingMelee = false;

    // Events
    public delegate void StateChange(PlayerState newState);
    public event StateChange OnStateChange;

    #region Public Methods

    public bool IsStateCurrentlyActive(PlayerState stateToCompare)
    {
        return currentState == stateToCompare;
    }

    public void ToUppercutState()
    {
        ChangeState(uppercutState);
    }

    public void ToIdleState()
    {
        ChangeState(idleState);
    }

    #endregion

    #region Private Methods

    private void Awake()
    {
        InitializeStates();

        player.GetMyDodgingComponent().OnDodge += HandleDodgeState;
        player.GetMyMeleeComponent().OnMelee += HandleMeleeState;

        this.m_RB = player.GetMyRB();
        this.m_feetCollider = player.GetMyFeetCollider();

        terrainLayerMask = player.GetTerrainLayerMask();
        playerRunningTreshold = player.GetRunningTreshold();
    }

    private void Update()
    {
        // TODO refactor state handling?
        HandleJumpingState();
        HandleUpwardState();
        HandleFallingState();
        HandleLandingState();
        HandleRunningState();
        HandleIdleState();
    }

    private void InitializeStates()
    {
        this.idleState = new PlayerGroundedState_Idle(player);
        this.runningState = new PlayerGroundedState_Running(player);
        this.jumpingState = new PlayerAerialState_Jumping(player);
        this.upwardState = new PlayerAerialState_Upward(player);
        this.fallingState = new PlayerAerialState_Falling(player);
        this.landingState = new PlayerGroundedState_Landing(player);
        this.dodgingState = new PlayerDodgingState(player);
        this.uppercutState = new PlayerMeleeState_Uppercut(player);

        player.SetState(idleState); //FIXME not elegant(?)

        currentState = idleState;

        ChangeState(idleState);
    }

    private void HandleJumpingState()
    {
        if (currentState == upwardState) return;

        if (isTouchingGround()) return;

        if (m_RB.velocity.y < 0.5f) return;

        ChangeState(jumpingState);
    }

    private void HandleUpwardState()
    {
        if (currentState == jumpingState) return;

        if (isTouchingGround()) return;

        if (m_RB.velocity.y < 0.5f) return;

        ChangeState(upwardState);
    }

    private void HandleFallingState()
    {
        if (isTouchingGround()) return;

        if (m_RB.velocity.y > 0) return;

        ChangeState(fallingState);
    }

    private void HandleLandingState()
    {
        if (!isTouchingGround()) return;

        // Must be jumping or falling
        if (currentState != fallingState && currentState != jumpingState) return;

        ChangeState(landingState);
    }

    private void HandleRunningState()
    {
        if (!isTouchingGround()) return;

        if (Mathf.Abs(m_RB.velocity.x) < playerRunningTreshold) return;

        ChangeState(runningState);
    }

    private void HandleIdleState()
    {
        if (!isTouchingGround()) return;

        if (Mathf.Abs(m_RB.velocity.x) > playerRunningTreshold) return;

        if (Mathf.Abs(m_RB.velocity.y) > 1) return;

        if (currentState == landingState) return;

        ChangeState(idleState);
    }

    private void HandleDodgeState(bool isDodging)
    {
        if (!isDodging) 
        {
            this.isDodging = false;
            ChangeState(fallingState);

            return;
        }

        ChangeState(dodgingState);

        this.isDodging = isDodging;
    }

    private void HandleMeleeState(bool isPerfomingMelee)
    {
        this.isPerfomingMelee = isPerfomingMelee;

        if (!isPerfomingMelee)
        {
            HandleUpwardState();
            HandleFallingState();
        }
    }

    private bool isTouchingGround()
    {
        return m_feetCollider.IsTouchingLayers(terrainLayerMask);
    }

    private bool isPerformingAction()
    {
        return isDodging || isPerfomingMelee;
    }

    /*
        ChangeState method is responsible for all state changing logic
        ForceChange param is used to forcefully change state regardless of conditions
    */

    private void ChangeState(PlayerState newState)
    {
        ChangeState(newState, false);
    }

    private void ChangeState(PlayerState newState, bool forceChange)
    {
        if (!forceChange)
        {   
            if (isPerformingAction()) return;

            if (newState == currentState) return;

            if (OnStateChange == null) return;
        }

        currentState = newState;
        
        currentState.InitializeState();

        // Change state UI display
        this.stateText.text = $"State: {currentState.GetStateName()}";

        // Emit event
        OnStateChange(currentState);
    }

    #endregion
}
