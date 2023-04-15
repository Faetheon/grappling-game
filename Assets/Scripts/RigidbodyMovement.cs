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

    public RigidbodyMovement(float acceleration, float topSpeed)
    {
        _acceleration = acceleration;
        _topSpeed = topSpeed;
    }

    public void Apply(Rigidbody rigidbody, Vector3 direction)
    {
        rigidbody.AddForce(direction * _acceleration, ForceMode.Acceleration);
    }
}
