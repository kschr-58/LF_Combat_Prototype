public interface CharacterState
{
    public void Enter();
    public void Exit();
    public void LogicUpdate();
    public void PhysicsUpdate();

    public void MoveHorizontally(float direction);
    public void Jump();
    public void EndJump();
    public void Dodge();
    public void Melee();
    public bool CanFlip();
}
