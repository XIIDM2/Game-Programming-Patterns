using UnityEngine;

namespace Patterns.FSM
{
    public class AirState : MovementState
    {
        protected const float AIR_MOVEMENT_MODIFIER = 0.7f;

        public override void FixedUpdate(PlayerController controller)
        {
            controller.Movement.Move(_direction * AIR_MOVEMENT_MODIFIER);
        }
    }
}