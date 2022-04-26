public abstract class EnemyHurtState : EnemyState
{
    protected EnemyHurtState(EnemyData enemyData) : base(enemyData) {}

    public override void Launch()
    {
        stateManager.ChangeState(stateManager._launchState);
    }
}
