using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutionTarget : Interactable
{
    [SerializeField] private EnemyData _enemyData;

    public override void Interact()
    {
        Slow();
    }

    private void Slow()
    {
        _enemyData.RB.gravityScale = 1f; //FIXME Magic number
        _enemyData.RB.velocity = Vector2.right * 0;
    }
}
