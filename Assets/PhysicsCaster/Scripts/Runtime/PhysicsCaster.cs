using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhysicsCasterRuntime
{
    public class PhysicsCaster : MonoBehaviour
    {
        [SerializeField] private Space _raySpace = Space.Self;
        [SerializeField] private Ray _ray = new Ray(Vector3.zero, Vector3.forward);
        [SerializeField] private float _maxDistance = Mathf.Infinity;
        [SerializeField] private LayerMask _layerMask = Physics.DefaultRaycastLayers;
        [SerializeField] private QueryTriggerInteraction _queryTriggerInteraction = QueryTriggerInteraction.UseGlobal;

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
            set => _maxDistance = value;
        }
        public LayerMask LayerMask
        {
            get => _layerMask;
            set => _layerMask = value;
        }
        public QueryTriggerInteraction QueryTriggerInteraction
        {
            get => _queryTriggerInteraction;
            set => _queryTriggerInteraction = value;
        }
    }
}
