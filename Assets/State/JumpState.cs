using UnityEngine;

public class JumpState : State
{
    private const float JUMP_CHECK_TIMER = 0.1f;
    private float _lastJumpPressed;

    private bool _isJumpFailed;

    public JumpState(float direction = 0.0f) : base(direction)
    {

    }

    public override State HandleInput(PlayerController controller, InputData inputData)
    {
        if (inputData.action == PlayerAction.Move) _direction = inputData.value ?? 0.0f;

        return null;

    }

    public override void Enter(PlayerController controller)
    {
        controller.Movement.Jump();
        _lastJumpPressed = Time.time;
    }

    public override void Update(PlayerController controller)
    {
        _isJumpFailed = Time.time > _lastJumpPressed + JUMP_CHECK_TIMER && controller.Movement.IsGrounded;

        if (!controller.Movement.IsGrounded) controller.ChangeState(new AirBorneState(_direction));
        else if (_isJumpFailed) controller.ChangeState(new MoveState(_direction));
    }

    public override void FixedUpdate(PlayerController controller)
    {
        controller.Movement.Move(_direction * AIR_MOVEMENT_MODIFIER);
    }
}
