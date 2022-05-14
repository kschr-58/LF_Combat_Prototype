using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundBounceState : EnemyHurtState
{
    public EnemyGroundBounceState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Hurt (Ground Bounce)";
        this.animationBool = "Hurt (Ground Bounce)";
    }

    public override void Enter()
    {
        base.Enter();

        isStateLocked = true;

        enemyData.RB.gravityScale = enemyData.GroundBounceGravity;

        nextVelocity = enemyData.GroundBounceVelocity;
        nextVelocity.x = enemyData.RB.velocity.x * 0.2f; //FIXME magic number

        enemyData.RB.velocity = nextVelocity;

        // Instantiate VFX
        ScreenEffectHandler.Instance.InstantiateVFX(enemyData.EffectLibrary.LandingEffect, enemyData.transform.position, Quaternion.identity, enemyData.transform.localScale);

        // Screen impact effect
        ScreenEffectHandler.Instance.TriggerBigImpact();

        // Screen shake
        CameraController.Instance.ShakeScreen(1.5f, 1.2f, 0.25f);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isStateLocked) return;

        // To knockdown transition
        if (isGrounded) stateManager.ChangeState(stateManager._knockdownState);
    }

    protected override void AnimationEndEvent()
    {
        isStateLocked = false;
    }
}
