using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateMachine : MonoBehaviour
{
    [SerializeField]
    private Character _character;
    [SerializeField]
    private CharacterIsWalking _isWalking;
    [SerializeField]
    private CharacterIsJumping _isJumping;
    [SerializeField]
    private CharacterIsAirborn _isAirborn;
    [SerializeField]
    private CharacterIsFiringGrapple _isFiringGrapple;

    private CharacterState _currentState;

    private void Awake()
    {
        _isWalking.enabled = false;
        _isJumping.enabled = false;
        _isAirborn.enabled = false;
        _isFiringGrapple.enabled = false;
        SetState(_isWalking);
    }
    public void SetIsWalking()
    {
        SetState(_isWalking);
    }
    public void SetIsJumping()
    {
        SetState(_isJumping);
    }
    public void SetIsAirborn()
    {
        SetState(_isAirborn);
    }
    public void SetIsFiringGrapple()
    {
        SetState(_isFiringGrapple);
    }
    public void SetState(CharacterState state)
    {
        if (_currentState != null)
        {
            _currentState.enabled = false;
        }
        _currentState = state;
        _currentState.enabled = true;
    }
    public void TriggerAction(CharacterAction action)
    {
        _currentState.TriggerAction(action);
    }
}
