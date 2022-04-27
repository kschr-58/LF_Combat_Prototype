using UnityEngine;

public class EnemyHurtDragState : EnemyHurtState
{
    public EnemyHurtDragState(EnemyData enemyData) : base(enemyData)
    {
        this.stateName = "Hurt (Drag)";
        this.animationBool = "Hurt (Drag)";
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Mathf.Abs(enemyData.RB.velocity.x) < 1) stateManager.ChangeState(stateManager._idleState);
    }
}
