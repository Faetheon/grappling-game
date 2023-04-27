using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Grapple Game/Character Configuration")]
public class CharacterConfiguration : ScriptableObject
{
    [SerializeField]
    private RigidbodyMovement _walkingMovement = new RigidbodyMovement(20, 5, 2);

    [Space]

    [SerializeField]
    private float _jumpSpeed = 10;
    [SerializeField]
    private float _maxJumpTime = 0.5f;
    [SerializeField]
    private RigidbodyMovement _airMovement = new RigidbodyMovement(10, 5, 1);

    [Space]

    [SerializeField]
    private GrappleProperties _grapple = new GrappleProperties(10, 10);
    [SerializeField]
    private RigidbodyMovement _walkingWhileFiringGrappleMovement = new RigidbodyMovement(10, 2, 1);

    public float MaxJumpTime => _maxJumpTime;

    public void ApplyWalkingMovement(Rigidbody rigidbody, Vector3 direction)
    {
        _walkingMovement.Move(rigidbody, direction);
    }
    public void SetJumpSpeed(Rigidbody rigidbody)
    {
        rigidbody.SetVelocityY(_jumpSpeed);
    }
    public void ApplyAirMovement(Rigidbody rigidbody, Vector3 direction)
    {
        _airMovement.Move(rigidbody, direction);
    }
    public void ApplyWalkingWhileFiringGrappleMovement(Rigidbody rigidbody, Vector3 direction)
    {
        _walkingWhileFiringGrappleMovement.Move(rigidbody, direction);
    }
}
