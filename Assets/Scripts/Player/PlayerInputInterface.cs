using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputInterface : MonoBehaviour
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

    public event Action<Vector2> OnStrafe = delegate { };
    public event Action<Vector2> OnAimDelta = delegate { };
    public event Action OnCursorGrab = delegate { };
    public event Action OnCursorRelease = delegate { };

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
            OnStrafe(obj.ReadValue<Vector2>());
        }
        if (action.name == _aimDeltaActionName)
        {
            OnAimDelta(obj.ReadValue<Vector2>());
        }
        if (action.name == _cursorGrabActionName)
        {
            OnCursorGrab();
        }
        if (action.name == _cursorReleaseActionName)
        {
            OnCursorRelease();
        }
    }
}
