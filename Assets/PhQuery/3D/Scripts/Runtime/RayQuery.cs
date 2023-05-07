using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhQuery
{
    public class RayQuery : PhysicsQuery
    {
        public override bool Cast()
        {
            return Cast(out _);
        }
        public override bool Cast(out RaycastHit hit)
        {
            Ray ray = GetWorldRay();
            return Physics.Raycast(ray, out hit, MaxDistance, LayerMask, TriggerInteraction);
        }
        public override RaycastHit[] CastAll()
        {
            Ray ray = GetWorldRay();
            return Physics.RaycastAll(ray, MaxDistance, LayerMask, TriggerInteraction);
        }
        public override int CastNonAlloc(out RaycastHit[] hits)
        {
            Ray ray = GetWorldRay();
            hits = GetHitCache();
            return Physics.RaycastNonAlloc(ray, hits, MaxDistance, LayerMask, TriggerInteraction);
        }
        public override bool Check()
        {
            return Cast();
        }
        public override RaycastHit[] Overlap()
        {
            return CastAll();
        }
        public override int OverlapNonAlloc(out RaycastHit[] hits)
        {
            return CastNonAlloc(out hits);
        }
    }
}
