using UnityEngine;

public class MoveState : State
{
    public MoveState(float direction = 0.0f) : base(direction)
    {

    }

    public override State HandleInput(PlayerController controller, InputData inputData)
    {
        if (controller.Movement.IsGrounded && inputData.action == PlayerAction.Jump) return new JumpState(_direction);

        _direction = inputData.value ?? 0.0f;

        return null;
    }

    public override void Update(PlayerController controller)
    {
        if (Mathf.Approximately(_direction, 0.0f)) controller.ChangeState(new IdleState());
    }

    public override void FixedUpdate(PlayerController controller)
    {
        controller.Movement.Move(_direction);
    }
}
