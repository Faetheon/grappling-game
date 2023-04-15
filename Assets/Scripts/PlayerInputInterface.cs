using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputInterface : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _input;
    [SerializeField]
    private string _strafeActionName = "Strafe";

    public event Action<Vector2> OnStrafe;

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
    }
}
