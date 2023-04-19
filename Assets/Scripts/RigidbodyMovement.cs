using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RigidbodyMovement
{
    [SerializeField]
    private float _acceleration = 20;
    [SerializeField]
    private float _topSpeed = 10;
    [SerializeField]
    private float _decelerationDrag = 2;
    [SerializeField]
    private float _decelerateThreshold = 0.001f;

    public RigidbodyMovement(float acceleration, float topSpeed, float delerationDrag)
    {
        _acceleration = acceleration;
        _topSpeed = topSpeed;
        _decelerationDrag = delerationDrag;
    }

    public void Move(Rigidbody rigidbody, Vector3 direction)
    {
        if (direction.magnitude > _decelerateThreshold)
        {
            Accelerate(rigidbody, direction);
        }
        else
        {
            Decelerate(rigidbody);
        }
    }
    private void Accelerate(Rigidbody rigidbody, Vector3 direction)
    {
        rigidbody.drag = 0;

        float velocityAlongDirection = Vector3.Dot(rigidbody.velocity, direction);
        if (velocityAlongDirection < _topSpeed)
        {
            rigidbody.AddForce(direction * _acceleration, ForceMode.Acceleration);
        }
    }
    private void Decelerate(Rigidbody rigidbody)
    {
        rigidbody.drag = _decelerationDrag;
    }
}
