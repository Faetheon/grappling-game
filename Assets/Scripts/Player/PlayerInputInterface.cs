using System;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerInputInterface : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _input;
    [SerializeField]
    private string _strafeActionName = "Strafe";
    [SerializeField]
    private string _aimDeltaActionName = "AimDelta";
    [SerializeField]
    private string _cursorGrabActionName = "CursorGrab";
    [SerializeField]
    private string _cursorReleaseActionName = "CursorRelease";
    [SerializeField]
    private string _jumpActionName = "Jump";
    [SerializeField]
    private string _grappleActionName = "Grapple";

    public event Action<Vector2> OnStrafe = delegate { };
    public event Action<Vector2> OnAimDelta = delegate { };
    public event Action OnCursorGrab = delegate { };
    public event Action OnCursorRelease = delegate { };
    public event Action OnJumpStart = delegate { };
    public event Action OnJumpStop = delegate { };
    public event Action OnGrappleStart = delegate { };
    public event Action OnGrappleStop = delegate { };

    private void Awake()
    {
        _input.notificationBehavior = PlayerNotifications.InvokeCSharpEvents;
        _input.onActionTriggered += Input_onActionTriggered;
    }
    private void OnDestroy()
    {
        _input.onActionTriggered -= Input_onActionTriggered;
    }
    private void Input_onActionTriggered(InputAction.CallbackContext obj)
    {
        InputAction action = obj.action;
        if (action.name == _strafeActionName)
        {
            ProcessValueAction(obj, OnStrafe);
        }
        if (action.name == _aimDeltaActionName)
        {
            ProcessValueAction(obj, OnAimDelta);
        }
        if (action.name == _cursorGrabActionName)
        {
            ProcessTriggerAction(obj, OnCursorGrab);
        }
        if (action.name == _cursorReleaseActionName)
        {
            ProcessTriggerAction(obj, OnCursorRelease);
        }
        if (action.name == _jumpActionName)
        {
            ProcessStartStopAction(obj, OnJumpStart, OnJumpStop);
        }
        if (action.name == _grappleActionName)
        {
            ProcessStartStopAction(obj, OnGrappleStart, OnGrappleStop);
        }
    }
    private void ProcessValueAction<T>(InputAction.CallbackContext context, Action<T> valueChangedAction)
        where T : struct
    {
        valueChangedAction(context.ReadValue<T>());
    }
    private void ProcessTriggerAction(InputAction.CallbackContext context, Action triggerAction)
    {
        triggerAction();
    }
    private void ProcessStartStopAction(InputAction.CallbackContext context, Action startAction, Action stopAction)
    {
        if (context.performed)
        {
            startAction();
        }
        if (context.canceled)
        {
            stopAction();
        }
    }
}
