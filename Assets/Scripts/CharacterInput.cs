using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class CharacterInput : MonoBehaviour
{
    [SerializeField, ReadOnly]
    private Vector2 _strafe;

    public Vector2 Strafe => _strafe;

    public void SetStrafe(Vector2 strafe)
    {
        _strafe = strafe;
    }
}
