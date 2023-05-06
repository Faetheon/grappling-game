using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhQuery
{
    public class NullQuery : PhysicsQuery
    {
        public override bool Cast()
        {
            return false;
        }
        public override bool Cast(out RaycastHit hit)
        {
            hit = new RaycastHit();
            return false;
        }
        public override RaycastHit[] CastAll()
        {
            return new RaycastHit[0];
        }
        public override RaycastHitCache CastNonAlloc()
        {
            RaycastHitCache cache = GetHitCache();
            cache.Size = 0;
            return cache;
        }
        public override bool Check()
        {
            return false;
        }
        public override RaycastHit[] Overlap()
        {
            return new RaycastHit[0];
        }
        public override RaycastHitCache OverlapNonAlloc()
        {
            RaycastHitCache cache = GetHitCache();
            cache.Size = 0;
            return cache;
        }
    }
}
