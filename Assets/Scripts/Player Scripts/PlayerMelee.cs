using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    // Serialized Fields
    [SerializeField] Player player;

    // Component References
    private Rigidbody2D m_rb;
    private PlayerStateHandler m_StateHandler;

    // Other References
    Vector2 nextVelocity;

    // Events
    public delegate void MeleeChange(bool isPerfomingMelee);
    public event MeleeChange OnMelee;

    #region Public Methods

    public void Uppercut()
    {
        if (OnMelee == null) return;

        m_StateHandler.ToUppercutState();
        OnMelee(true);

        // player.ResetVelocity();
        nextVelocity.x = m_rb.velocity.x + player.GetUppercutVelocity().x * player.transform.localScale.x;
        nextVelocity.y = player.GetUppercutVelocity().y;

        m_rb.velocity = nextVelocity;
    }

    public void AerialKick()
    {
        if (OnMelee == null) return;

        m_StateHandler.ToAerialKickState();
        OnMelee(true);

        // player.ResetVelocity();
        nextVelocity.x = m_rb.velocity.x + player.GetAerialKickVelocity().x * player.transform.localScale.x;
        nextVelocity.y = player.GetAerialKickVelocity().y;

        m_rb.velocity = nextVelocity;
    }

    public void FinishMelee()
    {
        OnMelee(false);
    }

    #endregion

    #region Private Methods

    private void Awake()
    {
        m_rb = player.GetMyRB();
        m_StateHandler = player.GetMyStateHandler();
    }

    #endregion
}
