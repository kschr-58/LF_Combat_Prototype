public interface CharacterState
{
    public void Enter();
    public void Exit();
    public void LogicUpdate();
    public void PhysicsUpdate();

    public void RegisterHorizontalInput(float direction);
    public void RegisterVerticalInput(float direction);
    public void Jump();
    public void EndJump();
    public void Dodge();
    public void Melee();
    public void Launch();
    public void ForwardLaunch();
    public void StraightForwardLaunch();
    public void Spike();
    public void LightHurt();
    public string GetStateName();
    public bool CanFlip();
    public float GetMeleeProximity();
}
