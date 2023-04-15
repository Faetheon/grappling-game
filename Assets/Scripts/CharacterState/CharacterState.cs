using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[System.Serializable]
public class CharacterState
{
    [SerializeField, ReadOnly, AllowNesting]
    private Character _character;
    [SerializeField, ReadOnly, AllowNesting]
    private float _startTime;

    public Character Character => _character;
    public float TimeSpentInState => Time.time - _startTime;

    public CharacterState(Character character)
    {
        _character = character;
    }
    public virtual void OnEnable()
    {
        _startTime = Time.time;
    }
    public virtual void OnDisable()
    {

    }
    public virtual void Update()
    {

    }
    public virtual void TriggerAction(CharacterAction action)
    {

    }
}
