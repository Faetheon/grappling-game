using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Grapple : MonoBehaviour
{
    [SerializeField]
    private GrappleProperties _properties;
    [SerializeField]
    private GrappleTether _tether;

    [SerializeField, ReadOnly]
    private GrapplePoint _point;

    public GrappleProperties Properties
    {
        get => _properties;
        set => _properties = value;
    }
    public float ExtendDuration => _properties.ExtendDuration;
    public float MaxDistance => _properties.MaxDistance;

    public delegate void GrappleFinishedDelegate(bool connectedToPoint);
    public event GrappleFinishedDelegate OnGrappleFinished = delegate { };

    private void Awake()
    {
        _tether.OnExtended += OnTetherExtended;
        _tether.OnRetracted += OnTetherRetracted;
    }
    private void OnDestroy()
    {
        _tether.OnExtended -= OnTetherExtended;
        _tether.OnRetracted -= OnTetherRetracted;
    }
    private void OnTetherExtended()
    {
        if (_point)
        {
            // Connect to point
            OnGrappleFinished(true);
        }
        else
        {
            _tether.Retract();
        }
    }
    private void OnTetherRetracted()
    {
        OnGrappleFinished(false);
    }

    public void Fire(Ray ray)
    {
        Vector3 endingPosition = ray.origin + ray.direction * _properties.MaxDistance;
        if (CastRay(ray, out RaycastHit hit))
        {
            SetPointFromRaycastHit(hit);
            endingPosition = hit.point;
        }
        _tether.ExtendToPoint(endingPosition);
    }
    private void SetPointFromRaycastHit(RaycastHit hit)
    {
        _point = hit.transform.GetComponent<GrapplePoint>();
    }
    private bool CastRay(Ray ray, out RaycastHit hitInfo)
    {
        return Physics.Raycast(ray, out hitInfo, _properties.MaxDistance, _properties.PhysicsCastMask);
    }
}
