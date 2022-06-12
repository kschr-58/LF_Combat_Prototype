using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedExecutionState : PlayerExecutionState
{
    public GroundedExecutionState(PlayerData playerData) : base(playerData)
    {
        this.stateName = "Execution (Grounded)";
        this.animationBool = "Execution (Grounded)";
    }

    public override void Enter()
    {
        base.Enter();

        CameraController.Instance.ToCinematicCamera(playerData.CinematicPoint);
    }

    protected override void AnimationEndEvent()
    {
        CameraController.Instance.SwitchOutCinematicCamera();
        
        stateManager.ChangeState(stateManager._idleState);
    }
}
