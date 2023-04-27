using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GrappleProperties
{
    [SerializeField]
    private float _maxDistance;
    [SerializeField]
    private float _travelSpeed;

    public float MaxDistance => _maxDistance;
    public float TravelSpeed => _travelSpeed;

    public GrappleProperties(float maxDistance, float travelSpeed)
    {
        _maxDistance = maxDistance;
        _travelSpeed = travelSpeed;
    }
}
