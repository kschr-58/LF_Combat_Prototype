using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetChasing : MonoBehaviour
{
    [SerializeField] EnemyData _enemyData;
    [SerializeField] Text TargetTextElement;

    GameObject _currentTarget;
    Vector2 _nextVelocity;

    #region Unity Callback Methods

    private void Start()
    {
        _enemyData.TargetDetectionComponent.NewTargetEvent += SetNewTarget;
    }

    #endregion

    #region Public Methods

    public void LoseTarget()
    {
        _currentTarget = null;

        // Subscribe to new target event
        _enemyData.TargetDetectionComponent.NewTargetEvent += SetNewTarget;
    }

    public void ChaseTarget()
    {
        if (!_currentTarget) return;

        MoveTowardsTarget();
        HandleObstacles();
        _enemyData.EnemyMeleeLogicComponent.CheckMeleeProximity(_currentTarget.transform);
    }

    public float GetDistanceToTarget()
    {
        float distance = Mathf.Abs(_currentTarget.transform.position.x - transform.position.x);
        
        return  distance;
    }

    public void FlipTowardsTarget()
    {
        if (!_currentTarget) return;
        
        Vector2 targetPosition = _currentTarget.transform.position;
        Vector3 newScale = transform.localScale;

        newScale.x = Mathf.Sign(targetPosition.x - transform.position.x);

        transform.localScale = newScale;
    }

    #endregion

    #region Private Methods

    private void SetNewTarget(GameObject newTarget)
    {
        TargetTextElement.text = $"Target: {newTarget.gameObject.name.ToString()}";

        // Set new target
        _currentTarget = newTarget;

        // Unsubscribe from new target event
        _enemyData.TargetDetectionComponent.NewTargetEvent -= SetNewTarget;
    }

    private void MoveTowardsTarget()
    {
        Vector2 targetPosition = _currentTarget.transform.position;

        // Check if target is already in proximity
        float distance = targetPosition.x - transform.position.x;

        if (Mathf.Abs(distance) <= _enemyData.DesiredProximity) return;

        // Compare x world position to decide direction
        float direction = Mathf.Sign(distance);

        // Move towards target position with velocity movementSpeed
        _nextVelocity.x = direction * _enemyData.MovementSpeed;
        _nextVelocity.y = _enemyData.RB.velocity.y;

        _enemyData.RB.velocity = _nextVelocity;
    }

    private void HandleObstacles()
    {
        // Check if moving
        if (Mathf.Abs(_enemyData.RB.velocity.x) < 1) return;

        if (_enemyData.SidesCollider.IsTouchingLayers(_enemyData.TerrainLayers)) Jump();
    }

    private void Jump()
    {
        if (!_enemyData.FeetCollider.IsTouchingLayers(_enemyData.TerrainLayers)) return;

        _nextVelocity.x = _enemyData.RB.velocity.x;
        _nextVelocity.y = _enemyData.JumpVelocity;

        _enemyData.RB.velocity = _nextVelocity;
    }

    #endregion
}
