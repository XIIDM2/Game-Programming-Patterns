using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputController : MonoBehaviour
{
    public event UnityAction<InputData> ActionTriggered;
    private PlayerInput _input;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();

        if (_input.notificationBehavior != PlayerNotifications.InvokeCSharpEvents)
        {
            Debug.LogError("Wrong Player Input Behavior for onActionTriggerEvents, please switch to 'Invoke C# Events' ");
        }

    }

    private void OnEnable()
    {
        _input.onActionTriggered += HandleAction;
    }

    private void OnDisable()
    {
        _input.onActionTriggered -= HandleAction;
    }

    private void HandleAction(InputAction.CallbackContext context)
    {
        switch (context.action.name)
        {
            case "Move":
                ActionTriggered?.Invoke(new InputData(PlayerAction.Move, context.ReadValue<Vector2>().x));
                break;
            case "Jump":
                if (context.started) ActionTriggered?.Invoke(new InputData(PlayerAction.Jump, null));
                break;
            case "Attack":
                if (context.started) ActionTriggered?.Invoke(new InputData(PlayerAction.Attack, null));
                break;
        }
    }

    #region C# InputSystemActions Script
    //private InputSystem_Actions inputActions;

    //private void Awake()
    //{
    //    inputActions = new InputSystem_Actions();
    //}

    //private void OnEnable()
    //{
    //    inputActions.Player.Move.performed += OnMovePerformed;
    //    inputActions.Player.Move.canceled += OnMoveCanceled;

    //    inputActions.Player.Jump.performed += OnJumpPerformed;
    //    inputActions.Player.Jump.canceled += OnJumpCanceled;

    //    inputActions.Player.Attack.performed += OnAttackPerformed;
    //    inputActions.Player.Attack.canceled += OnAttackCanceled;

    //    inputActions.Enable();

    //}

    //private void OnDisable()
    //{
    //    inputActions.Player.Move.performed -= OnMovePerformed;
    //    inputActions.Player.Move.canceled -= OnMoveCanceled;

    //    inputActions.Player.Jump.performed -= OnJumpPerformed;
    //    inputActions.Player.Jump.canceled -= OnJumpCanceled;

    //    inputActions.Player.Attack.performed -= OnAttackPerformed;
    //    inputActions.Player.Attack.canceled -= OnAttackCanceled;

    //    inputActions.Disable();
    //}
    //private void OnMovePerformed(InputAction.CallbackContext context)
    //{
    //    horizontalMovement?.Invoke(context.ReadValue<Vector2>().x);
    //}

    //private void OnMoveCanceled(InputAction.CallbackContext context)
    //{
    //    horizontalMovement?.Invoke(context.ReadValue<Vector2>().x);
    //}

    //private void OnJumpPerformed(InputAction.CallbackContext context)
    //{
    //    OnJumpPressed?.Invoke();
    //}

    //private void OnJumpCanceled(InputAction.CallbackContext context)
    //{
    //    OnJumpReleased?.Invoke();
    //}

    //private void OnAttackPerformed(InputAction.CallbackContext context)
    //{
    //    OnAttackPressed?.Invoke();
    //}

    //private void OnAttackCanceled(InputAction.CallbackContext context)
    //{
    //    OnAttackReleased?.Invoke();
    //}
    #endregion
}
