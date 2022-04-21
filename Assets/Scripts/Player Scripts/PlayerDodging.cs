using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDodging : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Text dodgeCountText; //TODO remove

    Rigidbody2D m_rB;
    Vector2 nextVelocity;
    Coroutine dodgeRegenCoroutine;
    int currentDodgeCount;

    public delegate void DodgingChange(bool isDodging);
    public event DodgingChange OnDodge;

    bool isDodging;

    #region Public Methods

    public void RunningDodge()
    {
        if (!CanDodge()) return;

        StartCoroutine(DodgeCoroutine(player.GetRunningDodgeTime()));
        StartCoroutine(RunningDodgeCoroutine());
    }

    public void StandingDodge()
    {
        if (!CanDodge()) return;

        StartCoroutine(DodgeCoroutine(player.GetRunningDodgeTime()));
        StartCoroutine(StandingDodgeCoroutine());
    }

    public void AerialDodge()
    {
        if (!CanDodge()) return;

        StartCoroutine(DodgeCoroutine(player.GetAerialDodgeTime()));
        StartCoroutine(AerialDodgeCoroutine());
    }

    #endregion

    #region Private Methods

    private void Start()
    {
        m_rB = player.GetMyRB();

        currentDodgeCount = player.GetMaxDodgeCount();
    }

    private void Update()
    {
        HandleDodgeRegen();

        dodgeCountText.text = $"Dodge count: {currentDodgeCount}";
    }

    private void HandleDodgeRegen()
    {
        if (dodgeRegenCoroutine != null) return;

        if (currentDodgeCount >= player.GetMaxDodgeCount()) return;

        dodgeRegenCoroutine = StartCoroutine(RegenDodge());
    }

    private bool CanDodge()
    {
        return !isDodging && (currentDodgeCount > 0);
    }
    
    #endregion

    #region Coroutines

    private IEnumerator RegenDodge()
    {
        yield return new WaitForSeconds(player.GetDodgeRegenTime());

        if (currentDodgeCount < player.GetMaxDodgeCount()) currentDodgeCount++;

        dodgeRegenCoroutine = null;
    }

    private IEnumerator DodgeCoroutine(float dodgeTime)
    {
        // Emit event
        OnDodge(true);

        this.currentDodgeCount--;
        this.isDodging = true;

        player.GetMyDodgeTrailComponent().ActivateTrail();

        yield return new WaitForSeconds(dodgeTime);

        // Emit event
        OnDodge(false);
        
        this.isDodging = false;

        player.GetMyDodgeTrailComponent().DeactivateTrail();
    }

    private IEnumerator RunningDodgeCoroutine()
    {
        float dodgeSpeed = player.GetRunningDodgeSpeed() * player.transform.localScale.x;

        while (isDodging)
        {
            nextVelocity.x = dodgeSpeed;
            nextVelocity.y = 0f;

            m_rB.velocity = nextVelocity;
            yield return null;
        }
    }

    private IEnumerator StandingDodgeCoroutine()
    {
        float dodgeSpeed = player.GetRunningDodgeSpeed() * -0.1f * player.transform.localScale.x;

        while (isDodging)
        {
            nextVelocity.x = dodgeSpeed;
            nextVelocity.y = 0f;

            m_rB.velocity = nextVelocity;
            yield return null;
        }
    }

    private IEnumerator AerialDodgeCoroutine()
    {
        float dodgeSpeed = player.GetAerialDodgeSpeed() * Mathf.Sign(m_rB.velocity.x);
        float defaultGravity = m_rB.gravityScale;

        m_rB.gravityScale = 0f;

        while (isDodging)
        {
            nextVelocity.x = dodgeSpeed;
            nextVelocity.y = 0f;

            m_rB.velocity = nextVelocity;
            yield return null;
        }

        m_rB.gravityScale = defaultGravity;
    }

    #endregion
}
