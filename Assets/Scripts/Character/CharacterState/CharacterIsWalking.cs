using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIsWalking : CharacterState
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
        Character.ApplyWalkingMovement();
    }
    public override void TriggerAction(CharacterAction action)
    {
        base.TriggerAction(action);
        if (action == CharacterAction.StartJumping)
        {
            Character.SetIsJumping();
        }
        if (action == CharacterAction.StartGrappling)
        {
            Character.SetIsFiringGrapple();
        }
    }

    private void Character_OnIsTouchingFloorChanged(bool obj)
    {
        if (!obj)
        {
            Character.SetIsAirborn();
        }
    }

}
