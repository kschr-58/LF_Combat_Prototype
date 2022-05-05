public abstract class EnemyHurtState : EnemyState
{
    protected bool isStateLocked;

    protected EnemyHurtState(EnemyData enemyData) : base(enemyData) {}

    public override void Exit()
    {
        base.Exit();

        enemyData.RB.gravityScale = enemyData.DefaultGravity;
    }

    protected override void AnimationEndEvent()
    {
        return;
    }
}
