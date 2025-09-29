using UnityEngine;
using UnityEngine.InputSystem;

namespace Patterns.Command
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerInputController : MonoBehaviour
    {
        private PlayerMovement _player;

        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();

            if (_playerInput.notificationBehavior != PlayerNotifications.InvokeCSharpEvents)
            {
                Debug.LogError("Wrong Player Input Behavior for onActionTriggerEvents, please switch to 'Invoke C# Events' ");
            }
        }

        private void Start()
        {
            _player = GetComponent<PlayerMovement>();
        }

        private void OnEnable()
        {
            _playerInput.onActionTriggered += HandleAction;
        }

        private void OnDisable()
        {
            _playerInput.onActionTriggered -= HandleAction;
        }

        private void HandleAction(InputAction.CallbackContext context)
        {
            switch (context.action.name)
            {
                case "Move":
                    if (context.action.triggered) OnMoveActionPressed(context.ReadValue<Vector2>());
                    break;
                case "Jump":
                    if (context.action.triggered) OnJumpActionPressed();
                    break;
                case "Crouch":
                    if (context.action.triggered) OnCrouchActionPressed();
                    break;

            }
        }

        private void OnMoveActionPressed(Vector2 value)
        {
            if (value.x > 0)
            {
                SendMoveCommand(_player, Vector3.right);
            }
            else if (value.x < 0)
            {
                SendMoveCommand(_player, Vector3.left);
            }

            if (value.y > 0)
            {
                SendMoveCommand(_player, Vector3.up);
            }
            else if (value.y < 0)
            {
                SendMoveCommand(_player, Vector3.down);
            }
        }

        private void SendMoveCommand(PlayerMovement player, Vector3 moveVector)
        {
            ICommand moveCommand = new MoveCommand(player, moveVector);

            CommandInvoker.ExecuteCommand(moveCommand); 
        }

        private void OnJumpActionPressed()
        {
            CommandInvoker.UndoCommand();
        }

        private void OnCrouchActionPressed()
        {
            CommandInvoker.RedoCommand();
        }
    }

}
