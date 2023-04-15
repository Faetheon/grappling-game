using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private CharacterConfiguration _configuration;
    [SerializeField]
    private CharacterInput _input;

    public void ApplyWalk()
    {
        _configuration.ApplyWalk(_rigidbody, _input.GetMovementVector());
    }
}
