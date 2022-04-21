using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateHandler : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Text stateText; //TODO remove

    BoxCollider2D m_feetCollider;
    Rigidbody2D m_RB;
    LayerMask terrainLayerMask;

    float playerRunningTreshold;

    // States
    PlayerState currentState;
    PlayerGroundedState_Idle idleState;
    PlayerGroundedState_Running runningState;
    PlayerAerialState_Jumping jumpingState;
    PlayerAerialState_Falling fallingState;
    PlayerGroundedState_Landing landingState;
    PlayerState_Dodging dodgingState;

    public delegate void StateChange(PlayerState newState);
    public event StateChange OnStateChange;
    
    #region Public Methods

    #endregion

    #region Private Methods

    private void Awake()
    {
        InitializeStates();

        player.GetMyDodgingComponent().OnDodge += HandleDodgeState;
    }

    private void Start()
    {
        this.m_RB = player.GetMyRB();
        this.m_feetCollider = player.GetMyFeetCollider();

        terrainLayerMask = player.GetTerrainLayerMask();
        playerRunningTreshold = player.GetRunningTreshold();
    }

    private void Update()
    {
        if (currentState == dodgingState) return;

        // TODO refactor state handling?
        HandleJumpingState();
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
        this.fallingState = new PlayerAerialState_Falling(player);
        this.landingState = new PlayerGroundedState_Landing(player);
        this.dodgingState = new PlayerState_Dodging(player);

        player.SetState(idleState); //FIXME not elegant(?)

        ChangeState(idleState);
    }

    private void HandleJumpingState()
    {
        if (isTouchingGround()) return;

        if (m_RB.velocity.y < 0.5f) return;

        if (currentState == jumpingState) return;

        ChangeState(jumpingState);
    }

    private void HandleFallingState()
    {
        if (isTouchingGround()) return;

        if (m_RB.velocity.y > 0) return;

        if (currentState == fallingState) return;

        ChangeState(fallingState);
    }

    private void HandleLandingState()
    {
        if (!isTouchingGround()) return;

        // Must be jumping or falling
        if (currentState != fallingState && currentState != jumpingState) return;

        if (currentState == landingState) return;

        ChangeState(landingState);
    }

    private void HandleRunningState()
    {
        if (!isTouchingGround()) return;

        if (Mathf.Abs(m_RB.velocity.x) < playerRunningTreshold) return;

        if (currentState == runningState) return;

        ChangeState(runningState);
    }

    private void HandleIdleState()
    {
        if (!isTouchingGround()) return;

        if (Mathf.Abs(m_RB.velocity.x) > playerRunningTreshold) return;

        if (currentState == landingState) return;

        if (currentState == idleState) return;

        ChangeState(idleState);
    }

    private void HandleDodgeState(bool isDodging)
    {
        if (!isDodging) 
        {
            ChangeState(fallingState);

            return;
        }

        if (currentState == dodgingState) return;

        ChangeState(dodgingState);
    }

    private bool isTouchingGround()
    {
        return m_feetCollider.IsTouchingLayers(terrainLayerMask);
    }

    /*
        ChangeState function is responsible for all state changing logic
    */
    private void ChangeState(PlayerState newState)
    {
        if (OnStateChange == null) return;

        currentState = newState;

        // Change animation based on new state
        currentState.ResetAnimationVariables();
        currentState.ChangeAnimation();

        // Change state UI display
        this.stateText.text = $"State: {currentState.GetStateName()}";

        // Emit event
        OnStateChange(currentState);
    }

    #endregion
}
