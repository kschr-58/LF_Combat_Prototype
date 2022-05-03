using UnityEngine;

public class EnemyHurtDragState : EnemyHurtState
{
    public EnemyHurtDragState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Hurt (Drag)";
        this.animationBool = "Hurt (Drag)";
    }

    public override void Enter()
    {
        base.Enter();

        enemyData.SmokeTrail.EnableTrail();
    }

    public override void Exit()
    {
        base.Exit();

        enemyData.SmokeTrail.DisableTrail();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Mathf.Abs(enemyData.RB.velocity.x) <= 0.1f) stateManager.ChangeState(stateManager._dragRecoverState);
    }

    public override bool CanFlip()
    {
        return true;
    }
}
