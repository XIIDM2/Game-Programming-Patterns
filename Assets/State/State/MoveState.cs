using UnityEngine;

namespace Patterns.FSM
{
    public class MoveState : GroundState
    {
        public override State HandleTransition(PlayerController controller)
        {
            if (Mathf.Approximately(controller.Movement.Velocity.x, 0.0f) && _direction == 0) return new IdleState();

            return base.HandleTransition(controller);
        }

        public override void Enter(PlayerController controller)
        {
            base.Enter(controller);

            controller.Animation.SetBoolParameter("IsMoving", true);
        }

        public override void Exit(PlayerController controller)
        {
            base.Exit(controller);

            controller.Animation.SetBoolParameter("IsMoving", false);
        }
    }
}