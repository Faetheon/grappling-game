using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RigidbodyExtensions
{
    public static void SetVelocityX(this Rigidbody rigidbody, float x)
    {
        rigidbody.velocity = rigidbody.velocity.SetX(x);
    }
    public static void SetVelocityY(this Rigidbody rigidbody, float y)
    {
        rigidbody.velocity = rigidbody.velocity.SetY(y);
    }
    public static void SetVelocityZ(this Rigidbody rigidbody, float z)
    {
        rigidbody.velocity = rigidbody.velocity.SetZ(z);
    }
    public static void SetVelocityDimension(this Rigidbody rigidbody, int dimension, float value)
    {
        rigidbody.velocity = rigidbody.velocity.SetDimension(dimension, value);
    }
}
