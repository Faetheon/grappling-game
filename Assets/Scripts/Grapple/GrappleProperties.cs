using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GrappleProperties
{
    [SerializeField]
    private float _maxDistance;
    [SerializeField]
    private float _extendDuration;
    [SerializeField]
    private LayerMask _physicsCastMask;

    public float MaxDistance => _maxDistance;
    public float ExtendDuration => _extendDuration;
    public LayerMask PhysicsCastMask => _physicsCastMask;

    public GrappleProperties(float maxDistance, float extendDuration, LayerMask physicsCastMask)
    {
        _maxDistance = maxDistance;
        _extendDuration = extendDuration;
        _physicsCastMask = physicsCastMask;
    }
}
