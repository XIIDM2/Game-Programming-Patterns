using UnityEngine;

public class AirBorneState : State
{

    public AirBorneState(float direction = 0.0f) : base(direction)
    {
    }

    public override State HandleInput(PlayerController controller, InputData inputData)
    {
        if (inputData.action == PlayerAction.Move) _direction = inputData.value ?? 0.0f;

        return null;

    }

    public override void Update(PlayerController controller)
    {
        if (controller.Movement.IsGrounded)
        {
            controller.ChangeState(new MoveState(_direction));       
        }
            
    }

    public override void FixedUpdate(PlayerController controller)
    {
        controller.Movement.Move(_direction * AIR_MOVEMENT_MODIFIER);
    }
}