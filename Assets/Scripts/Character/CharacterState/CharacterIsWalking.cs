using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterIsWalking : CharacterState
{
    public CharacterIsWalking(Character character) 
        : base(character)
    {

    }
    public override void Update()
    {
        base.Update();
        Character.ApplyWalk();
    }
}
