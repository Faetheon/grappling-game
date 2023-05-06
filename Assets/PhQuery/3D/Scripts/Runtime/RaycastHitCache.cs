using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhQuery
{
    public class RaycastHitCache
    {
        private RaycastHit[] _hits;
        private int _size;

        public int Size
        {
            get => _size;
            set
            {
                if (value < 0 || value > Capacity)
                {
                    throw new InvalidOperationException($"Ray cast hit cache with capacity {Capacity} " +
                        $"cannot have a size of {value}");
                }
                _size = value;
            }
        }
        public int Capacity
        {
            get => _hits.Length;
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException($"Ray cast hit cache " +
                        $"must have a non-negative capacity");
                }
                if (_hits == null)
                {
                    _hits = new RaycastHit[value];
                }
                if (_hits.Length != value)
                {
                    RaycastHit[] oldHits = _hits;
                    _hits = new RaycastHit[value];
                    Array.Copy(oldHits, _hits, Mathf.Min(oldHits.Length, _hits.Length));
                }
            }
        }
        internal RaycastHit[] Hits => _hits;

        internal RaycastHitCache(int capacity)
        {
            _size = 0;
            Capacity = capacity;
        }

        public RaycastHit Get(int i)
        {
            if (i < 0 || i >= _size)
            {
                throw new IndexOutOfRangeException($"Cannot access ray cast hit at index {i} " +
                    $"for a cache with size {_size}");
            }
            return _hits[i];
        }
    }
}
