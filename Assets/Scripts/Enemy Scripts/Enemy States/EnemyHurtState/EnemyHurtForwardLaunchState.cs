using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtForwardLaunchState : EnemyHurtState
{
    public EnemyHurtForwardLaunchState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Hurt (Forward Launch)";
        this.animationBool = "Hurt (Forward Launch)";
    }

    public override void Enter()
    {
        base.Enter();

        isStateLocked = true;

        enemyData.RB.gravityScale = enemyData.LaunchGravity;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        HandleStateLock();

        // To wallsplat transition
        if (enemyData.SidesCollider.IsTouchingLayers(enemyData.TerrainLayerMask)) stateManager.ChangeState(stateManager._wallsplatState);

        // Following transitions can only occur while not state locked
        if (isStateLocked) return;

        // To tumble transition
        if (isGrounded && Mathf.Abs(enemyData.RB.velocity.x) > 8) stateManager.ChangeState(stateManager._tumbleState); //FIXME magic number

        // To drag transition
        else if (isGrounded) stateManager.ChangeState(stateManager._dragState);
    }

    public override bool CanFlip()
    {
        return true;
    }

    private void HandleStateLock()
    {
        if (!isGrounded && isStateLocked) isStateLocked = false;
    }
}
