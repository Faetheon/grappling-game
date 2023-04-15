using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateMachine : MonoBehaviour
{
    [SerializeField]
    private Character _character;
    [SerializeField]
    private CharacterIsWalking _isWalking;

    private CharacterState _currentState;

    private void Awake()
    {
        _isWalking = new CharacterIsWalking(_character);
        SetState(_isWalking);
    }
    public void SetState(CharacterState state)
    {
        if (_currentState != null)
        {
            _currentState.OnDisable();
        }
        _currentState = state;
        _currentState.OnEnable();
    }
    public void TriggerAction(CharacterAction action)
    {
        _currentState.TriggerAction(action);
    }
}
