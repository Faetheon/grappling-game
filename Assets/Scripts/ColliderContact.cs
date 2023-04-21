using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderContact : MonoBehaviour
{
    [SerializeField]
    private RigidbodyIsSleepingEvents _rigidbodyIsSleeping;
    [SerializeField]
    private Collider _collider;
    [SerializeField]
    private LayerMask _layerMask;
    [SerializeField]
    private float _boxVerticalExtent = 0.001f;

    private bool _isTouchingFloor = false;
    public bool IsTouchingFloor => _isTouchingFloor;

    public event System.Action<bool> OnIsTouchingFloorChanged = delegate { };

    private void Reset()
    {
        _rigidbodyIsSleeping = GetComponent<RigidbodyIsSleepingEvents>();
        _collider = GetComponent<Collider>();
    }
    private void OnDrawGizmosSelected()
    {
        bool isTouchingFloor = CalculateIsTouchingFloor();
        if (isTouchingFloor)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }

        Vector3 center = GetBoxCastCenter();
        Vector3 size = GetBoxCastExtents() * 2;
        float distance = GetBoxCastDistance();
        Vector3 endCenter = center + Vector3.down * distance;

        Gizmos.DrawWireCube(center, size);
        Gizmos.DrawLine(center, endCenter);
        Gizmos.DrawWireCube(endCenter, size);
    }

    private void Awake()
    {
        _rigidbodyIsSleeping.OnIsSleepingChanged += RigidbodyIsSleeping_OnIsSleepingChanged;
    }
    private void OnDestroy()
    {
        _rigidbodyIsSleeping.OnIsSleepingChanged -= RigidbodyIsSleeping_OnIsSleepingChanged;
    }
    private void Update()
    {
        bool previousIsTouchingFloor = _isTouchingFloor;
        _isTouchingFloor = CalculateIsTouchingFloor();
        if (previousIsTouchingFloor != _isTouchingFloor)
        {
            OnIsTouchingFloorChanged(_isTouchingFloor);
        }
    }
    private void RigidbodyIsSleeping_OnIsSleepingChanged(bool obj)
    {
        enabled = !obj;
    }
    private bool CalculateIsTouchingFloor()
    {
        Vector3 center = GetBoxCastCenter();
        Vector3 extents = GetBoxCastExtents();
        float distance = GetBoxCastDistance();
        return Physics.BoxCast(center, extents, Vector3.down, Quaternion.identity, distance, _layerMask, QueryTriggerInteraction.Ignore);
    }
    private Vector3 GetBoxCastCenter()
    {
        Bounds bounds = _collider.bounds;
        Vector3 center = bounds.center;
        Vector3 min = bounds.min;
        float boxVerticalSize = _boxVerticalExtent * 2f;
        return new Vector3(center.x, min.y + boxVerticalSize, center.z);
    }
    private Vector3 GetBoxCastExtents()
    {
        Vector3 colliderExtents = _collider.bounds.extents;
        return new Vector3(colliderExtents.x, _boxVerticalExtent, colliderExtents.y);
    }
    private float GetBoxCastDistance()
    {
        return _boxVerticalExtent * 3f;
    }
}
