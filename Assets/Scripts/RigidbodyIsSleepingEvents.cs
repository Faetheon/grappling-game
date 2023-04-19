using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyIsSleepingEvents : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;

    private bool _isSleeping;
    public bool IsSleeping => _isSleeping;

    public event Action<bool> OnIsSleepingChanged  = delegate { };

    private void FixedUpdate()
    {
        bool previousIsSleeping = _isSleeping;
        _isSleeping = _rigidbody.IsSleeping();
        if (previousIsSleeping != _isSleeping)
        {
            OnIsSleepingChanged(_isSleeping);
        }
    }
}
