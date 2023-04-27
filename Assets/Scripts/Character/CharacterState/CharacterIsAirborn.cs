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

    private void Character_OnIsTouchingFloorChanged(bool obj)
    {
        Character.SetIsWalking();
    }
}
