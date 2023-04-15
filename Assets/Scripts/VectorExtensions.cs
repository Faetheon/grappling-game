using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtensions
{
    public static Vector2 SetX2(this Vector2 vector, float x)
    {
        return vector.SetDimension2(0, x);
    }
    public static Vector2 SetY2(this Vector2 vector, float y)
    {
        return vector.SetDimension2(1, y);
    }
    public static Vector2 SetDimension2(this Vector2 vector, int dimension, float value)
    {
        vector[dimension] = value;
        return vector;
    }

    public static Vector3 SetX3(this Vector3 vector, float x)
    {
        return vector.SetDimension3(0, x);
    }
    public static Vector3 SetY3(this Vector3 vector, float y)
    {
        return vector.SetDimension3(1, y);
    }
    public static Vector3 SetZ3(this Vector3 vector, float z)
    {
        return vector.SetDimension3(2, z);
    }
    public static Vector3 SetDimension3(this Vector3 vector, int dimension, float value)
    {
        vector[dimension] = value;
        return vector;
    }
}
