using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtensions
{
    public static Vector3 SetX(this Vector3 vector, float x)
    {
        return vector.SetDimension(0, x);
    }
    public static Vector3 SetY(this Vector3 vector, float y)
    {
        return vector.SetDimension(1, y);
    }
    public static Vector3 SetZ(this Vector3 vector, float z)
    {
        return vector.SetDimension(2, z);
    }
    public static Vector3 SetDimension(this Vector3 vector, int dimension, float value)
    {
        vector[dimension] = value;
        return vector;
    }
}
