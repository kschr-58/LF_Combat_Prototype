using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageManager : MonoBehaviour
{
    [SerializeField] EnemyData _enemyData;

    public void Launch()
    {
        _enemyData.GetCurrentState().Launch();
    }

    public void ForwardLaunch()
    {

    }

    public void StraightForwardLaunch()
    {

    }
}
