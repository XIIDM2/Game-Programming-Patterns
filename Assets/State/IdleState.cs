using UnityEngine;

public class IdleState : State
{
    public override State HandleInput(PlayerController controller, InputData inputData)
    {
        switch (inputData.action)
        {
            case PlayerAction.Move:
                return new MoveState();
            case PlayerAction.Jump:
                if (controller.Movement.IsGrounded) return new JumpState();
                return null;
            default: 
                return null;
        }

    }

    public override void Enter(PlayerController controller)
    {
        controller.Movement.Move(ZERO_MOVEMENT_SPEED);
    }
}
