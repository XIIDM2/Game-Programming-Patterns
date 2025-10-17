using UnityEngine;

namespace Patterns.FSM
{
    public class NonAttackState : State
    {
        public override State HandleInput(PlayerController controller, InputData inputData)
        {
            if (inputData.action == PlayerAction.Attack) return new AttackState();
            return base.HandleInput(controller, inputData);
        }
    }
}