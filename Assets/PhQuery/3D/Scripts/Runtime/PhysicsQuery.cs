using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhQuery
{
    public abstract class PhysicsQuery : MonoBehaviour
    {
        [SerializeField] private Space _raySpace = Space.Self;
        [SerializeField] private Ray _ray = new Ray(Vector3.zero, Vector3.forward);
        [SerializeField] private float _maxDistance = Mathf.Infinity;
        [SerializeField] private LayerMask _layerMask = Physics.DefaultRaycastLayers;
        [SerializeField] private QueryTriggerInteraction _triggerInteraction = QueryTriggerInteraction.UseGlobal;
        [SerializeField] private int _maxCachedHits = 8;

        private RaycastHitCache _hitCache;

        public Space RaySpace
        {
            get => _raySpace;
            set => _raySpace = value;
        }
        public Ray Ray
        {
            get => _ray;
            set => _ray = value;
        }
        public float MaxDistance
        {
            get => _maxDistance;
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException($"Max distance of physics query must be non-negative");
                }
                _maxDistance = value;
            }
        }
        public LayerMask LayerMask
        {
            get => _layerMask;
            set => _layerMask = value;
        }
        public QueryTriggerInteraction TriggerInteraction
        {
            get => _triggerInteraction;
            set => _triggerInteraction = value;
        }
        public int MaxCachedHits
        {
            get => _maxCachedHits;
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException($"Max cached hits of physics query must be non-negative");
                }
                _maxCachedHits = value;
            }
        }

        internal RaycastHitCache GetHitCache()
        {
            if (_hitCache == null)
            {
                _hitCache = new RaycastHitCache(_maxCachedHits);
            }
            else
            {
                _hitCache.Capacity = _maxCachedHits;
            }
            return _hitCache;
        }
        internal Ray GetWorldRay()
        {
            if (_raySpace == Space.Self)
            {
                Vector3 start = transform.TransformPoint(_ray.origin);
                Vector3 end = transform.TransformPoint(_ray.origin + _ray.direction);
                return new Ray(start, end - start);
            }
            return _ray;
        }

        private void OnValidate()
        {
            _maxDistance = Mathf.Max(0, _maxDistance);
            _maxCachedHits = Mathf.Max(0, _maxCachedHits);
        }

        public abstract bool Cast();
        public abstract bool Cast(out RaycastHit hit);
        public abstract RaycastHit[] CastAll();
        public abstract RaycastHitCache CastNonAlloc();
        public abstract bool Check();
        public abstract RaycastHit[] Overlap();
        public abstract RaycastHitCache OverlapNonAlloc();
    }
}
