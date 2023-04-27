using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterIsFiringGrapple : CharacterState
{
    public override void OnEnable()
    {
        base.OnEnable();
        Character.FireGrapple();
        Character.OnGrappleFinished += GrappleFinished;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        Character.OnGrappleFinished -= GrappleFinished;
    }
    private void GrappleFinished(bool connectedToPoint)
    {
        if (Character.IsTouchingFloor)
        {
            Character.SetIsWalking();
        }
        else
        {
            Character.SetIsAirborn();
        }
    }
}
