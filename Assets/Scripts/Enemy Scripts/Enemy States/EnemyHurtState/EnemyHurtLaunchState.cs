using UnityEngine;

public class EnemyHurtLaunchState : EnemyHurtState
{
    public EnemyHurtLaunchState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Hurt (Launch)";
        this.animationBool = "Hurt (Launch)";
    }

    public override void Enter()
    {
        base.Enter();

        isAnimationLocked = true;

        enemyData.RB.gravityScale = enemyData.LaunchGravity;
    }

    public override void LogicUpdate()
    {
        if (!isGrounded && isAnimationLocked) isAnimationLocked = false;

        if (isGrounded && !isAnimationLocked) stateManager.ChangeState(stateManager._idleState);
    }

    public override bool CanFlip()
    {
        return true;
    }
}
