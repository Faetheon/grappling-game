using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerInputInterface _inputInterface;
    [SerializeField]
    private CharacterInput _characterInput;

    [SerializeField, ReadOnly]
    private Vector2 _aimDelta;

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
        _characterInput.RotateAimPivot(0, obj.x, 0, Space.World);
        _characterInput.RotateAimPivot(obj.y, 0, 0, Space.Self);
    }
}
