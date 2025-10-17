using UnityEngine;

namespace Patterns.FSM
{
    public class StandingState : State
    {
        public override State HandleInput(PlayerController controller, InputData inputData)
        {
            if (inputData.action == PlayerAction.Crouch) return new CrouchState();

            return base.HandleInput(controller, inputData);
        }
    }
}