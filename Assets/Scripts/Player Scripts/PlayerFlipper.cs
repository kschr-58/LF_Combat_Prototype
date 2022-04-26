using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlipper : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;

    Vector2 nextScale;
    float flipVelocityTreshold;

    private void Start()
    {
        nextScale = transform.localScale;
        
        this.flipVelocityTreshold = _playerData.FlipVelocityTreshold;
    }
    
    private void Update()
    {
        float horizontalVelocity = _playerData.RB.velocity.x;

        if (Mathf.Abs(horizontalVelocity) < flipVelocityTreshold) return;

        if (Mathf.Sign(horizontalVelocity) == transform.localScale.x) return;

        if (_playerData.GetCurrentState().CanFlip()) Flip();
    }

    private void Flip()
    {
        nextScale.x = Mathf.Sign(_playerData.RB.velocity.x);
        nextScale.y = transform.localScale.y;

        transform.localScale = nextScale;
    }
}
