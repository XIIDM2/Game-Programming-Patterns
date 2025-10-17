using UnityEngine;

namespace Patterns.FSM
{
    public class JumpState : AirState
    {
        private const float JUMP_CHECK_TIMER = 0.1f;

        private float _lastJumpPressed;

        private bool _isJumpFailed;

        public override void Enter(PlayerController controller)
        {
            base.Enter(controller);

            controller.Movement.Jump();

            _lastJumpPressed = Time.time;

            controller.Animation.SetTriggerParameter("Jump");

        }

        public override State HandleTransition(PlayerController controller)
        {
            _isJumpFailed = Time.time > _lastJumpPressed + JUMP_CHECK_TIMER && controller.Movement.IsGrounded;

            if (_isJumpFailed)
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

            if (!_isJumpFailed && controller.Movement.Velocity.y < 0) return new FallingState();

            return base.HandleTransition(controller);
        }
    }
}