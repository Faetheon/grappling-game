using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Character _character;
    [SerializeField]
    private PlayerConfiguration _configuration;
    [SerializeField]
    private PlayerInputInterface _inputInterface;

    [SerializeField, ReadOnly]
    private Vector2 _aim;

    private void Awake()
    {
        _inputInterface.OnStrafe += InputInterface_OnStrafe;
        _inputInterface.OnAimDelta += InputInterface_OnAimDelta;
        _inputInterface.OnJumpStart += InputInterface_OnJumpStart;
        _inputInterface.OnJumpStop += InputInterface_OnJumpStop;
    }
    private void OnDestroy()
    {
        _inputInterface.OnStrafe -= InputInterface_OnStrafe;
        _inputInterface.OnAimDelta -= InputInterface_OnAimDelta;
        _inputInterface.OnJumpStart -= InputInterface_OnJumpStart;
        _inputInterface.OnJumpStop -= InputInterface_OnJumpStop;
    }

    private void InputInterface_OnStrafe(Vector2 obj)
    {
        _character.SetStrafe(obj);
    }
    private void InputInterface_OnAimDelta(Vector2 obj)
    {
        obj = ConvertAimDelta(obj);
        AccumulateAimDelta(obj);
        _character.SetAimPivotLocalEulerAngles(_aim.y, _aim.x, 0);
    }
    private void InputInterface_OnJumpStart()
    {
        _character.TriggerAction(CharacterAction.StartJumping);
    }
    private void InputInterface_OnJumpStop()
    {
        _character.TriggerAction(CharacterAction.StopJumping);
    }

    private Vector2 ConvertAimDelta(Vector2 delta)
    {
        delta *= _configuration.AimSensitivity * Time.deltaTime;
        delta.y *= _configuration.AimYInversionSign;
        return delta;
    }
    private void AccumulateAimDelta(Vector2 delta)
    {
        _aim += delta;
        _aim.y = Mathf.Clamp(_aim.y, _configuration.MinVerticalAimAngle, _configuration.MaxVerticalAimAngle);
    }
}
