using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RigidbodyExtensions
{
    public static void SetVelocityX(this Rigidbody rigidbody, float x)
    {
        rigidbody.velocity = rigidbody.velocity.SetX3(x);
    }
    public static void SetVelocityY(this Rigidbody rigidbody, float y)
    {
        rigidbody.velocity = rigidbody.velocity.SetY3(y);
    }
    public static void SetVelocityZ(this Rigidbody rigidbody, float z)
    {
        rigidbody.velocity = rigidbody.velocity.SetZ3(z);
    }
    public static void SetVelocityDimension(this Rigidbody rigidbody, int dimension, float value)
    {
        rigidbody.velocity = rigidbody.velocity.SetDimension3(dimension, value);
    }
}
