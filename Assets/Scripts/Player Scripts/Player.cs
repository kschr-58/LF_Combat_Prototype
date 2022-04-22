using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Player script is responsible for storing player related values and components
Child components access these stored values and components with getters and setters
*/
public class Player : MonoBehaviour
{
    // Serialized fields
    [Header("Components")]
    [SerializeField] Rigidbody2D m_rB;
    [SerializeField] BoxCollider2D m_feetCollider;
    [SerializeField] PlayerJumping m_jumpingComponent;
    [SerializeField] PlayerDodging m_dodgingComponent;
    [SerializeField] DodgeTrail m_dodgeTrailComponent;
    [SerializeField] PlayerMelee m_meleeComponent;
    [SerializeField] Animator m_animator;
    [SerializeField] Arms m_arms;
    [SerializeField] PlayerStateHandler m_stateHandler;
    [SerializeField] AnimationTransmitter m_animationTransmitter;

    [Header("Movement Properties")]
    [SerializeField] float runSpeed;
    [SerializeField] float jumpHeight;
    [SerializeField] float shortHopModifier;
    [SerializeField] LayerMask terrainLayerMask;
    [SerializeField] float flipVelocityTreshold;
    [Tooltip("Determines at what velocity the player is considered running")]
    [SerializeField] float runningTreshold;

    [Header("Dodging Properties")]
    [SerializeField] int maxDodgeCount;
    [SerializeField] float dodgeRegenTime;
    [SerializeField] float runningDodgeTime;
    [SerializeField] float runningDodgeSpeed;
    [SerializeField] float standingDodgeTime;
    [SerializeField] float aerialDodgeTime;
    [SerializeField] float aerialDodgeSpeed;

    [Header("Melee Properties")]
    [SerializeField] Vector2 uppercutVelocity;

    // Other references
    PlayerState currentState;

    #region Public Methods

    public void ResetVelocity()
    {
        m_rB.velocity = new Vector2(0, 0);
    }

    #endregion

    #region Private Methods

    private void Start()
    {
        m_stateHandler.OnStateChange += SetState;
    }

    #endregion

    #region Getters & Setters

    public Rigidbody2D GetMyRB()
    {
        return m_rB;
    }

    public BoxCollider2D GetMyFeetCollider()
    {
        return m_feetCollider;
    }

    public PlayerState GetCurrentState()
    {
        return currentState;
    }

    public float GetRunSpeed()
    {
        return runSpeed;
    }

    public float GetJumpHeight()
    {
        return jumpHeight;
    }
    
    public float GetShortHopModifier()
    {
        return shortHopModifier;
    }

    public float GetFlipVelocityTreshold()
    {
        return flipVelocityTreshold;
    }

    public int GetMaxDodgeCount()
    {
        return maxDodgeCount;
    }

    public float GetDodgeRegenTime()
    {
        return dodgeRegenTime;
    }

    public float GetRunningDodgeTime()
    {
        return runningDodgeTime;
    }

    public float GetRunningDodgeSpeed()
    {
        return runningDodgeSpeed;
    }

    public float GetStandingDodgeTime()
    {
        return standingDodgeTime;
    }

    public float GetAerialDodgeTime()
    {
        return aerialDodgeTime;
    }

    public float GetAerialDodgeSpeed()
    {
        return aerialDodgeSpeed;
    }

    public LayerMask GetTerrainLayerMask()
    {
        return terrainLayerMask;
    }

    public PlayerJumping GetMyJumpingComponent()
    {
        return m_jumpingComponent;
    }

    public PlayerDodging GetMyDodgingComponent()
    {
        return m_dodgingComponent;
    }

    public DodgeTrail GetMyDodgeTrailComponent()
    {
        return m_dodgeTrailComponent;
    }

    public PlayerMelee GetMyMeleeComponent()
    {
        return m_meleeComponent;
    }

    public Animator GetMyAnimator()
    {
        return m_animator;
    }

    public AnimationTransmitter GetMyAnimationTransmitter()
    {
        return m_animationTransmitter;
    }

    public PlayerStateHandler GetMyStateHandler()
    {
        return m_stateHandler;
    }

    public Arms GetMyArms()
    {
        return m_arms;
    }

    public float GetRunningTreshold()
    {
        return runningTreshold;
    }

    public Vector2 GetUppercutVelocity()
    {
        return uppercutVelocity;
    }

    public void SetState(PlayerState newState)
    {
        this.currentState = newState;
    }

    #endregion
}
