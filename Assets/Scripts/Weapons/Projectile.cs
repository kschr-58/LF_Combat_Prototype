using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject _particlesPrefab;
    [SerializeField] private float _damage;
    [SerializeField] private float _travelSpeed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private Vector2 _knockBackVelocity;

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
        CharacterData targetData = collider.GetComponentInParent<CharacterData>();
        Rigidbody2D colliderRB = collider.GetComponentInParent<Rigidbody2D>();

        // Failsafe in case components are not present
        if (!targetData|| !colliderRB) return;

        // Make horizontal knockback relative to bullet direction
        Vector2 knockbackForce = _knockBackVelocity;
        knockbackForce.x *= _initialDirection;

        colliderRB.velocity = knockbackForce;

        targetData.HurtManager.ChangeDirection(_initialDirection);
        targetData.HurtManager.LightHurt();

        // Deal damage
        targetData.DamageSystem.DealDamage(_damage);

        // Notify combo manager
        ComboManager.s_instance.OnComboHit(targetData.transform);
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
