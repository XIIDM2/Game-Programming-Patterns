using UnityEngine;

namespace Patterns.FSM
{
    public class CrouchState : State
    {
        public override State HandleInput(PlayerController controller, InputData inputData)
        {
            if (inputData.action == PlayerAction.Crouch) return new StandingState();
            return base.HandleInput(controller, inputData);
        }

        public override void Enter(PlayerController controller)
        {
            base.Enter(controller);

            controller.Animation.SetBoolParameter("IsCrouching", true);
        }

        public override void Exit(PlayerController controller)
        {
            base.Exit(controller);


            controller.Animation.SetBoolParameter("IsCrouching", false);
        }
    }
}