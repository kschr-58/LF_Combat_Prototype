using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlipper : MonoBehaviour
{
    [SerializeField] Player player;

    Rigidbody2D m_RB;
    Vector2 nextScale;
    float flipVelocityTreshold;

    private void Start()
    {
        nextScale = transform.localScale;
        
        this.flipVelocityTreshold = player.GetFlipVelocityTreshold();
        this.m_RB = player.GetMyRB();
    }
    
    private void Update()
    {
        float horizontalVelocity = m_RB.velocity.x;

        if (Mathf.Abs(horizontalVelocity) < flipVelocityTreshold) return;

        if (Mathf.Sign(horizontalVelocity) == transform.localScale.x) return;

        if (player.GetCurrentState().CanFlip()) Flip();
    }

    private void Flip()
    {
        nextScale.x = Mathf.Sign(m_RB.velocity.x);
        nextScale.y = transform.localScale.y;

        transform.localScale = nextScale;
    }
}
