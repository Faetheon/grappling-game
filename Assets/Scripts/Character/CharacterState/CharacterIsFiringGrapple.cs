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
    }
    public override void OnDisable()
    {
        base.OnDisable();
    }
}
