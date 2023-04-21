using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private CharacterConfiguration _configuration;
    [SerializeField]
    private CharacterInput _input;
    [SerializeField]
    private CharacterStateMachine _stateMachine;
    [SerializeField]
    private ColliderContact _contact;

    public float MaxJumpTime => _configuration.MaxJumpTime;

    public event System.Action<bool> OnIsTouchingFloorChanged = delegate { };

    private void Awake()
    {
        _contact.OnIsTouchingFloorChanged += Contact_OnIsTouchingFloorChanged;
    }
    private void OnDestroy()
    {
        _contact.OnIsTouchingFloorChanged -= Contact_OnIsTouchingFloorChanged;
    }
    private void Contact_OnIsTouchingFloorChanged(bool obj)
    {
        OnIsTouchingFloorChanged(obj);
    }

    public void ApplyWalkingMovement()
    {
        _configuration.ApplyWalkingMovement(_rigidbody, _input.GetMovementVector());
    }
    public void SetJumpSpeed()
    {
        _configuration.SetJumpSpeed(_rigidbody);
    }
    public void ApplyAirMovement()
    {
        _configuration.ApplyAirMovement(_rigidbody, _input.GetMovementVector());
    }
    public void ApplyWalkingWhileFiringGrappleMovement()
    {
        _configuration.ApplyWalkingWhileFiringGrappleMovement(_rigidbody, _input.GetMovementVector());
    }

    public void SetStrafe(Vector2 strafe)
    {
        _input.SetStrafe(strafe);
    }
    public void SetAimPivotLocalEulerAngles(float x, float y, float z)
    {
        _input.SetAimPivotLocalEulerAngles(x, y, z);
    }

    public void SetIsWalking()
    {
        _stateMachine.SetIsWalking();
    }
    public void SetIsJumping()
    {
        _stateMachine.SetIsJumping();
    }
    public void SetIsAirborn()
    {
        _stateMachine.SetIsAirborn();
    }
    public void TriggerAction(CharacterAction action)
    {
        _stateMachine.TriggerAction(action);
    }
}
