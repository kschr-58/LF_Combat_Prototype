using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeLogic : MonoBehaviour
{
    [SerializeField] EnemyData _enemyData;

    private float _meleeDelayTimer;

    #region Unity Callback methods

    private void Start()
    {
        _meleeDelayTimer = 0;
    }

    private void Update()
    {
        if (_meleeDelayTimer <= 0) return;

        _meleeDelayTimer -= Time.deltaTime;
    }

    #endregion

    #region Public Methods

    public void CheckMeleeProximity(Transform targetTransform)
    {
        if (_meleeDelayTimer > 0) return;

        float meleeProximity = _enemyData.GetCurrentState().GetMeleeProximity();

        float distanceToTarget = Mathf.Abs(targetTransform.position.x - _enemyData.transform.position.x);

        if (distanceToTarget <= meleeProximity)
        {
            _enemyData.GetCurrentState().Melee();

            return;
        }
    }

    public void AddMeleeDelay(float delayTime)
    {
        _meleeDelayTimer += delayTime;
    }

    #endregion
}
