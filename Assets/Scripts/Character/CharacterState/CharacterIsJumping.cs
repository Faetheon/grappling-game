using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterIsJumping : CharacterState
{
    public override void Update()
    {
        base.Update();
        Character.ApplyAirMovement();
        Character.SetJumpSpeed();

        if (TimeSpentInState >= Character.MaxJumpTime)
        {
            Character.SetIsAirborn();
        }
    }
    public override void TriggerAction(CharacterAction action)
    {
        base.TriggerAction(action);
        if (action == CharacterAction.StopJumping)
        {
            Character.SetIsAirborn();
        }
        if (action == CharacterAction.StartGrappling)
        {
            Character.SetIsFiringGrapple();
        }
    }
}
