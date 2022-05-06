using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetChasing : MonoBehaviour
{
    [SerializeField] EnemyData enemyData;
    [SerializeField] Text TargetTextElement;

    GameObject currentTarget;
    Vector2 nextVelocity;

    #region Unity Callback Methods

    private void Start()
    {
        enemyData.TargetDetectionComponent.NewTargetEvent += SetNewTarget;
    }

    #endregion

    #region Public Methods

    public void LoseTarget()
    {
        currentTarget = null;

        // Subscribe to new target event
        enemyData.TargetDetectionComponent.NewTargetEvent += SetNewTarget;
    }

    public void ChaseTarget()
    {
        if (!currentTarget) return;

        MoveTowardsTarget();
        HandleObstacles();
        // FlipTowardsTarget();
    }

    #endregion

    #region Private Methods

    private void SetNewTarget(GameObject newTarget)
    {
        TargetTextElement.text = $"Target: {newTarget.gameObject.name.ToString()}";

        // Set new target
        currentTarget = newTarget;

        // Unsubscribe from new target event
        enemyData.TargetDetectionComponent.NewTargetEvent -= SetNewTarget;
    }

    private void FlipTowardsTarget()
    {
        Vector2 targetPosition = currentTarget.transform.position;
        Vector3 newScale = transform.localScale;

        newScale.x = Mathf.Sign(targetPosition.x - transform.position.x);

        transform.localScale = newScale;
    }

    private void MoveTowardsTarget()
    {
        Vector2 targetPosition = currentTarget.transform.position;

        // Check if target is already in proximity
        float distance = targetPosition.x - transform.position.x;

        if (Mathf.Abs(distance) <= enemyData.DesiredProximity) return;

        // Compare x world position to decide direction
        float direction = Mathf.Sign(distance);

        // Move towards target position with velocity movementSpeed
        nextVelocity.x = direction * enemyData.MovementSpeed;
        nextVelocity.y = enemyData.RB.velocity.y;

        enemyData.RB.velocity = nextVelocity;
    }

    private void HandleObstacles()
    {
        // Check if moving
        if (Mathf.Abs(enemyData.RB.velocity.x) < 1) return;

        if (enemyData.SidesCollider.IsTouchingLayers(enemyData.TerrainLayers)) Jump();
    }

    private void Jump()
    {
        if (!enemyData.FeetCollider.IsTouchingLayers(enemyData.TerrainLayers)) return;

        nextVelocity.x = enemyData.RB.velocity.x;
        nextVelocity.y = enemyData.JumpVelocity;

        enemyData.RB.velocity = nextVelocity;
    }

    #endregion
}
