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

        isStateLocked = true;

        enemyData.RB.gravityScale = enemyData.LaunchGravity;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        HandleStateLock();

        // To recover transition
        if (isGrounded && !isStateLocked) stateManager.ChangeState(stateManager._recoverLightState);
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
