using UnityEngine;

namespace Patterns.FSM
{
    public class GroundState : MovementState
    {
        public override State HandleInput(PlayerController controller, InputData inputData)
        {
            if (controller.Movement.IsGrounded && inputData.action == PlayerAction.Jump) return new JumpState();

            return base.HandleInput(controller, inputData);
        }

        public override State HandleTransition(PlayerController controller)
        {
            if (!controller.Movement.IsGrounded && controller.Movement.Velocity.y < 0) return new FallingState();

            return base.HandleTransition(controller);
        }

        public override void Enter(PlayerController controller)
        {
            base.Enter(controller);

            controller.Animation.SetBoolParameter("IsGrounded", true);
        }

        public override void Exit(PlayerController controller)
        {
            base.Exit(controller);

            controller.Animation.SetBoolParameter("IsGrounded", false);
        }
    }
}