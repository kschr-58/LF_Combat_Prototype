using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboTarget : MonoBehaviour
{
    //Serialized Fields
    [SerializeField] private DamageSystem _damageSystem;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Vector2 _hitVelocity;
    [SerializeField] private GameObject _hitSparksPrefab;

    // Other Fields
    private Vector2 _nextVelocity;

    public void GetHit(Vector2 hitPosition)
    {
        _damageSystem.DealDamage(15f);
        
        ComboManager.s_instance.OnComboHit(transform);
        CameraController.s_instance.ShakeScreen(0.2f);
        
        _nextVelocity = _hitVelocity;

        int hitDirection = (int) Mathf.Sign(hitPosition.x - transform.position.x);

        _nextVelocity.x *= -hitDirection;

        _rb.velocity = _nextVelocity;

        // VFX
        GameObject newVFX = Instantiate(_hitSparksPrefab, transform.position, transform.rotation);

        Destroy(newVFX, 1f);
    }
}
