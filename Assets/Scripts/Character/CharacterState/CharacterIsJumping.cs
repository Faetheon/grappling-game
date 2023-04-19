using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIsJumping : CharacterState
{
    public CharacterIsJumping(Character character) : base(character) { }

    public override void Update()
    {
        base.Update();
        Character.ApplyAirMovement();
        Character.SetJumpSpeed();

        if (TimeSpentInState >= Character.MaxJumpTime)
        {
            // Set state to "air"
        }
    }
    public override void TriggerAction(CharacterAction action)
    {
        base.TriggerAction(action);
        if (action == CharacterAction.StopJumping)
        {
            // Set state to "air"
        }
    }
}
