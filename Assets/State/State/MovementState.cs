using UnityEngine;

namespace Patterns.FSM
{
    public class MovementState : State
    {
        protected float _direction = 0.0f;

        public override State HandleInput(PlayerController controller, InputData inputData)
        {
            if (inputData.action == PlayerAction.Move) _direction = inputData.value ?? 0.0f;

            return null;
        }

        public override void Enter(PlayerController controller)
        {
            _direction = controller.Movement.LastDirection;
        }

        public override void FixedUpdate(PlayerController controller)
        {
            controller.Movement.Move(_direction);
        }

        public override void Exit(PlayerController controller)
        {
            controller.Movement.SetLastDirection(_direction);
        }

    }
}