using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerConfiguration _configuration;
    [SerializeField]
    private PlayerInputInterface _inputInterface;
    [SerializeField]
    private CharacterInput _characterInput;

    [SerializeField, ReadOnly]
    private Vector2 _aimDelta;
    [SerializeField, ReadOnly]
    private float _verticalAngle = 0;

    private void Awake()
    {
        _inputInterface.OnStrafe += InputInterface_OnStrafe;
        _inputInterface.OnAimDelta += InputInterface_OnAimDelta;
    }
    private void OnDestroy()
    {
        _inputInterface.OnStrafe -= InputInterface_OnStrafe;
    }
    private void InputInterface_OnStrafe(Vector2 obj)
    {
        _characterInput.SetStrafe(obj);
    }
    private void InputInterface_OnAimDelta(Vector2 obj)
    {
        obj = ConvertAimDelta(obj);
        _characterInput.RotateAimPivot(0, obj.x, 0, Space.World);
        _characterInput.RotateAimPivot(obj.y, 0, 0, Space.Self);
        ClampAimPivotRotation();
    }
    private Vector2 ConvertAimDelta(Vector2 delta)
    {
        delta *= _configuration.AimSensitivity * Time.deltaTime;
        delta.y *= _configuration.AimYInversionSign;
        return delta;
    }
    private void ClampAimPivotRotation()
    {
        Vector3 euler = _characterInput.GetAimPivotLocalEulerAngles();
        if (euler.x <= 180)
        {
            euler.x = Mathf.Min(euler.x, _configuration.MaxVerticalAimAngle);
        }
        else
        {
            euler.x = Mathf.Max(euler.x, 360 - _configuration.MaxVerticalAimAngle);
        }
        _characterInput.SetAimPivotLocalEulerAngles(euler);
    }
}
