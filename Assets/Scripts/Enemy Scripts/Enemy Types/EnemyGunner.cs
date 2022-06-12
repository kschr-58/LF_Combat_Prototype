using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunner : EnemyType
{
    [SerializeField] private EnemyData _enemyData;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _barrelPosition;

    private GameObject _currentTarget;

    private void Start()
    {
        _enemyData.TargetDetectionComponent.NewTargetEvent += SetNewTarget;
    }

    public void FireWeapon()
    {
        Vector3 vectorTarget = transform.right * transform.localScale.x;

        float angle = Mathf.Atan2(vectorTarget.y, vectorTarget.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Instantiate(_projectilePrefab, _barrelPosition.transform.position, targetRotation, ParticlesCollection.Singleton.transform);
    }

    private void SetNewTarget(GameObject newTarget)
    {
        _currentTarget = newTarget;
    }
}
