using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForwardLaunchState : EnemyHurtState
{
    public EnemyForwardLaunchState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Hurt (Forward Launch)";
        this.animationBool = "Hurt (Forward Launch)";
    }
    // TODO remove state lock logic

    public override void Enter()
    {
        base.Enter();

        // isStateLocked = true;

        enemyData.RB.gravityScale = enemyData.LaunchGravity;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        // HandleStateLock();

        // To wallslump transition
        if (enemyData.SidesCollider.IsTouchingLayers(enemyData.TerrainLayerMask) && isGrounded) stateManager.ChangeState(stateManager._wallslumpState);

        // To wallsplat transition
        if (enemyData.SidesCollider.IsTouchingLayers(enemyData.TerrainLayerMask)) stateManager.ChangeState(stateManager._wallsplatState);

        // Following transitions can only occur while not state locked
        // if (isStateLocked) return;

        // To tumble transition
        if (isGrounded && Mathf.Abs(enemyData.RB.velocity.x) > 8) stateManager.ChangeState(stateManager._tumbleState); //FIXME magic number

        // To drag transition
        else if (isGrounded) stateManager.ChangeState(stateManager._dragState);
    }

    // private void HandleStateLock()
    // {
    //     if (!isGrounded && isStateLocked) isStateLocked = false;
    // }
}
