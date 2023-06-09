using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterIsAirborn : CharacterState
{
    public override void OnEnable()
    {
        base.OnEnable();
        Character.OnIsTouchingFloorChanged += Character_OnIsTouchingFloorChanged;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        Character.OnIsTouchingFloorChanged -= Character_OnIsTouchingFloorChanged;
    }
    public override void Update()
    {
        base.Update();
        Character.ApplyAirMovement();
    }
    public override void TriggerAction(CharacterAction action)
    {
        base.TriggerAction(action);
        if (action == CharacterAction.StartGrappling)
        {
            Character.SetIsFiringGrapple();
        }
    }

    private void Character_OnIsTouchingFloorChanged(bool obj)
    {
        Character.SetIsWalking();
    }
}
