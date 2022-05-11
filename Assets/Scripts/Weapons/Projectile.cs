using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject _particlesPrefab;
    [SerializeField] float _travelSpeed;
    [SerializeField] float _lifeTime;
    [SerializeField] Vector2 _knockBackVelocity;

    private Rigidbody2D _rb;
    private int _initialDirection;

    #region Public Methods

    #endregion

    #region Private Methods
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.velocity = transform.right * _travelSpeed;

        _initialDirection = (int) Mathf.Sign(_rb.velocity.x);
        
        StartCoroutine(LifeTimeCoroutine());
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        HitTarget(col.collider);

        GameObject newParticles = Instantiate(_particlesPrefab, transform.position, transform.rotation, ParticlesCollection.Singleton.transform);
        Destroy(gameObject);
    }

    private void HitTarget(Collider2D collider)
    {
        // Check for target
        DamageManager damageManager = collider.GetComponentInParent<DamageManager>();
        Rigidbody2D colliderRB = collider.GetComponentInParent<Rigidbody2D>();

        // Failsafe in case components are not present
        if (!damageManager || !colliderRB) return;

        // Make horizontal knockback relative to bullet direction
        Vector2 knockbackForce = _knockBackVelocity;
        knockbackForce.x *= _initialDirection;

        colliderRB.velocity = knockbackForce;

        damageManager.FaceAggresor(_initialDirection);
        damageManager.LightHurt();
    }

    #endregion

    #region Coroutines

    private IEnumerator LifeTimeCoroutine()
    {
        yield return new WaitForSeconds(_lifeTime);

        Destroy(gameObject);
    }

    #endregion
}
