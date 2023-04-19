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

    public float MaxJumpTime => _configuration.MaxJumpTime;

    public void ApplyWalkingMovement()
    {
        _configuration.ApplyWalkingMovement(_rigidbody, _input.GetMovementVector());
    }
    public void ApplyAirMovement()
    {
        _configuration.ApplyAirMovement(_rigidbody, _input.GetMovementVector());
    }
    public void SetJumpSpeed()
    {
        _configuration.SetJumpSpeed(_rigidbody);
    }
}
