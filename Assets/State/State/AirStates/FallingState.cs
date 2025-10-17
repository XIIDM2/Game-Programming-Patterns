using UnityEngine;

namespace Patterns.FSM
{
    public class FallingState : AirState
    {
        public override State HandleTransition(PlayerController controller)
        {
            if (controller.Movement.IsGrounded)
            {
                if (Mathf.Approximately(controller.Movement.Velocity.x, 0.0f))
                {
                    return new IdleState();
                }
                else
                {
                    return new MoveState();

                }
            }

            return base.HandleTransition(controller);
        }

        public override void Enter(PlayerController controller)
        {
            base.Enter(controller);

            controller.Animation.SetBoolParameter("IsFalling", true);
        }

        public override void Exit(PlayerController controller)
        {
            base.Exit(controller);

            controller.Animation.SetBoolParameter("IsFalling", false);
        }
    }
}