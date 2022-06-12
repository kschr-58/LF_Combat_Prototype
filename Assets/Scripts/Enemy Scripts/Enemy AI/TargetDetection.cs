using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetection : MonoBehaviour
{
    [SerializeField] EnemyData enemyData;

    private bool isDetecting;

    public delegate void OnNewTarget(GameObject newTarget);
    public event OnNewTarget NewTargetEvent;

    #region Unity Callback Methods

    private void Start()
    {
        this.isDetecting = true;
    }

    private void FixedUpdate()
    {
        if (isDetecting) DetectTargets();
    }

    #endregion

    #region Public Methods

    public void SetDetecting(bool isDetecting)
    {
        this.isDetecting = isDetecting;
    }

    #endregion

    #region Private Methods

    private void DetectTargets()
    {
        // Circle cast in detection range radius to find possible targets
        RaycastHit2D raycastHit = Physics2D.CircleCast(transform.position, enemyData.DetectionRadius, Vector2.right, 0f, enemyData.TargetLayers);

        if (!raycastHit) return;

        GameObject potentialTarget = raycastHit.transform.gameObject;

        // Check if target is obscured
        bool isObscured = IsTargetObscured(potentialTarget.transform);

        if (isObscured) return;

        // Invoke new target event
        GameObject newTarget = potentialTarget;

        NewTargetEvent?.Invoke(newTarget);

        // Stop detecting new targets
        SetDetecting(false);
    }

    private bool IsTargetObscured(Transform target)
    {
        Vector2 direction = (target.position - transform.position).normalized;

        // Debug.DrawLine(transform.position, target.position);
        Debug.DrawLine(transform.position, target.position, Color.red);

        // Raycast to see if target is obscured by terrain
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, enemyData.ObstructionLayers);

        if (!raycastHit) return true;

        GameObject obstruction = raycastHit.transform.gameObject;

        // Check if obstruction and target are the same object
        bool isObscured = obstruction != target.gameObject;

        return isObscured;
    }

    #endregion

    #region Debugging

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, enemyData.DetectionRadius);
    }

    #endregion
}
