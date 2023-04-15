using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class CharacterInput : MonoBehaviour
{
    [SerializeField]
    private Transform _aimRotationPivot;
    [SerializeField]
    private Transform _aim;

    [SerializeField, ReadOnly]
    private Vector2 _strafe;

    public void SetStrafe(Vector2 strafe)
    {
        _strafe = strafe;
    }
    public Vector3 GetMovementVector()
    {
        // TODO: change this to use the normal of the player's contact with ground
        return Vector3.ProjectOnPlane(TransformStrafeToAimSpace(), Vector3.up).normalized;
    }
    private Vector3 TransformStrafeToAimSpace()
    {
        return _aim.TransformDirection(ConvertStrafeTo3D());
    }
    private Vector3 ConvertStrafeTo3D()
    {
        return new Vector3(_strafe.x, 0, _strafe.y);
    }
}
