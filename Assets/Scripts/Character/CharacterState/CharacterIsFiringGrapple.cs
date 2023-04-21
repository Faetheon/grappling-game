using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterIsFiringGrapple : CharacterState
{
    public CharacterIsFiringGrapple(Character character) : base(character) { }
    public override void OnEnable()
    {
        base.OnEnable();
    }
    public override void OnDisable()
    {
        base.OnDisable();
    }
}
