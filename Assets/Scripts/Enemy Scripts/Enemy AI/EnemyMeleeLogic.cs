using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeLogic : MonoBehaviour
{
    [SerializeField] EnemyData _enemyData;

    private bool _canMelee;

    private Coroutine _meleeDelayCoroutine;

    #region Unity Callback methods

    private void Start()
    {
        _canMelee = true;
    }

    #endregion

    #region Public Methods

    public void CheckMeleeProximity(Transform targetTransform)
    {
        if (!_canMelee) return;

        float meleeProximity = _enemyData.GetCurrentState().GetMeleeProximity();

        float distanceToTarget = Mathf.Abs(targetTransform.position.x - _enemyData.transform.position.x);

        if (distanceToTarget <= meleeProximity)
        {
            _canMelee = false;

            _meleeDelayCoroutine = StartCoroutine(MeleeDelayCoroutine());

            _enemyData.GetCurrentState().Melee();

            return;
        }
    }

    #endregion

    #region Coroutines

    private IEnumerator MeleeDelayCoroutine()
    {
        yield return new WaitForSeconds(_enemyData.MeleeAttackDelay);
        _canMelee = true;
        _meleeDelayCoroutine = null;
    }

    #endregion
}
