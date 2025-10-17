using UnityEngine;

namespace Patterns.FSM
{
    public class IdleState : GroundState
    {
        private const float ZERO_MOVEMENT_SPEED = 0.0f;

        private const float RESET_INPUT_VALUE = 0.0f;

        public override State HandleInput(PlayerController controller, InputData inputData)
        {
            if (inputData.action == PlayerAction.Move) return new MoveState();

            return base.HandleInput(controller, inputData);
        }

        public override void Enter(PlayerController controller)
        {
            base.Enter(controller);

            _direction = RESET_INPUT_VALUE;

            controller.Movement.Move(ZERO_MOVEMENT_SPEED);
        }

    }
}