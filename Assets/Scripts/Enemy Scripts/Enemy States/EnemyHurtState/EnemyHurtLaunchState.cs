using UnityEngine;

public class EnemyHurtLaunchState : EnemyHurtState
{
    bool _isAnimationLocked;

    public EnemyHurtLaunchState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Hurt (Launch)";
        this.animationBool = "Hurt (Launch)";
    }

    public override void Enter()
    {
        base.Enter();

        _isAnimationLocked = true;

        enemyData.RB.gravityScale = enemyData.LaunchGravity;
    }

    public override void LogicUpdate()
    {
        if (!isGrounded && _isAnimationLocked) _isAnimationLocked = false;

        if (isGrounded && !_isAnimationLocked) stateManager.ChangeState(stateManager._idleState);
    }

    protected override void AnimationEndEvent()
    {
        return;
    }
}
