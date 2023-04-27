using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class CharacterState : MonoBehaviour
{
    [SerializeField]
    private Character _character;
    [SerializeField, ReadOnly]
    private float _startTime;

    public Character Character => _character;
    public float TimeSpentInState => Time.time - _startTime;

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
