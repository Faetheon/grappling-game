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
        _isWalking = new CharacterIsWalking(_character);
        _isJumping = new CharacterIsJumping(_character);
        _isAirborn = new CharacterIsAirborn(_character);
        _isFiringGrapple = new CharacterIsFiringGrapple(_character);
        SetState(_isWalking);
    }
    private void Update()
    {
        _currentState.Update();
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
