using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFlipper : MonoBehaviour
{
    [SerializeField] CharacterData _characterData;

    Vector2 nextScale;

    private void Start()
    {
        nextScale = transform.localScale;
    }
    
    private void Update()
    {
        float horizontalVelocity = _characterData.RB.velocity.x;

        if (Mathf.Abs(horizontalVelocity) < _characterData.FlipVelocityTreshold) return;

        if (Mathf.Sign(horizontalVelocity) == transform.localScale.x) return;

        if (_characterData.GetCurrentState().CanFlip()) Flip();
    }

    private void Flip()
    {
        nextScale.x = Mathf.Sign(_characterData.RB.velocity.x);
        nextScale.y = transform.localScale.y;

        transform.localScale = nextScale;
    }
}
