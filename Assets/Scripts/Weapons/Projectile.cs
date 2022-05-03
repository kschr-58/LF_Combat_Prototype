using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject _particlesPrefab;
    [SerializeField] float _travelSpeed;
    [SerializeField] float _lifeTime;
    [SerializeField] Vector2 _knockBackVelocity;

    Rigidbody2D m_rB;

    #region Public Methods

    #endregion

    #region Private Methods
    private void Start()
    {
        m_rB = GetComponent<Rigidbody2D>();

        m_rB.velocity = transform.right * _travelSpeed;
        
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
        DamageManager damageManager = collider.GetComponent<DamageManager>();
        Rigidbody2D colliderRB = collider.GetComponent<Rigidbody2D>();

        // Failsafe in case components are not present
        if (!damageManager || !colliderRB) return;

        // Make horizontal knockback relative to bullet direction
        Vector2 knockbackForce = _knockBackVelocity;
        knockbackForce.x *= Mathf.Sign(colliderRB.velocity.x);

        colliderRB.velocity = knockbackForce;

        damageManager.Shot();
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
