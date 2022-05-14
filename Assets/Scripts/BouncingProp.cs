using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BouncingProp : Prop
{
    [SerializeField] float bounceHeight;

    private Rigidbody2D _rb;

    protected override void Start()
    {
        base.Start();

        _rb = GetComponent<Rigidbody2D>();
    }

    protected override void OnBigImpact()
    {
        Vector2 nextVelocity = _rb.velocity;

        nextVelocity.x = 0;
        nextVelocity.y = bounceHeight;

        _rb.velocity = nextVelocity;
    }
}
