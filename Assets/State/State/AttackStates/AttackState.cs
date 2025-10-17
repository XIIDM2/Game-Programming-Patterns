using UnityEngine;

namespace Patterns.FSM
{
    public class AttackState : State
    {
        private const float ATTACK_MOVEMENT_MODIFIER = 0.0f;
        public override State HandleInput(PlayerController controller, InputData inputData)
        {
            if (inputData.action == PlayerAction.StopAttack) return new NonAttackState();
            return base.HandleInput(controller, inputData);
        }

        public override void Enter(PlayerController controller)
        {
            base.Enter(controller);

            controller.Attack.Attack();

            controller.Animation.SetBoolParameter("IsAttacking", true);
        }

        public override void FixedUpdate(PlayerController controller)
        {
            base.FixedUpdate(controller);

            controller.Movement.Move(ATTACK_MOVEMENT_MODIFIER);
        }

        public override void Exit(PlayerController controller)
        {
            base.Exit(controller);

            controller.Animation.SetBoolParameter("IsAttacking", false);
        }
    }
}