using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhQuery
{
    public class EmptyQuery : PhysicsQuery
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
        public override int CastNonAlloc(out RaycastHit[] hits)
        {
            hits = GetHitCache();
            return 0;
        }
        public override bool Check()
        {
            return false;
        }
        public override RaycastHit[] Overlap()
        {
            return new RaycastHit[0];
        }
        public override int OverlapNonAlloc(out RaycastHit[] hits)
        {
            hits = GetHitCache();
            return 0;
        }
    }
}
