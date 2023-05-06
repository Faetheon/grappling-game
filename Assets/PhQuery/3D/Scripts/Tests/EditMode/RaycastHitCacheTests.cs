using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace PhQuery.EditModeTests
{
    public class RaycastHitCacheTests
    {
        private RaycastHitCache _cache;

        [Test]
        public void TestSizeProperty()
        {
            int capacity = 8;
            CreateCache(capacity);

            AssertSizeEqualsAfterSet(4);
            AssertSizeEqualsAfterSet(0);
            AssertSizeEqualsAfterSet(capacity);

            Assert.Throws<InvalidOperationException>(() => _cache.Size = capacity + 1);
            Assert.AreEqual(_cache.Size, capacity);
            Assert.Throws<InvalidOperationException>(() => _cache.Size = -1);
            Assert.AreEqual(_cache.Size, capacity);
        }
        [Test]
        public void TestCapacityProperty()
        {
            int capacity = 8;
            CreateCache(capacity);

            Assert.AreEqual(_cache.Capacity, capacity);

            _cache.Capacity = capacity + 1;
            Assert.AreEqual(_cache.Capacity, capacity + 1);

            _cache.Capacity = capacity - 1;
            Assert.AreEqual(_cache.Capacity, capacity - 1);

            Assert.Throws<InvalidOperationException>(() => _cache.Capacity = -1);
            Assert.AreEqual(_cache.Capacity, capacity - 1);
        }

        [Test]
        public void TestConstructor()
        {
            int capacity = 8;
            CreateCache(capacity);
            Assert.AreEqual(_cache.Size, 0);
            Assert.AreEqual(_cache.Capacity, capacity);
            Assert.Throws<InvalidOperationException>(() => CreateCache(-1));
        }
        [Test]
        public void TestGetMethod()
        {
            int capacity = 8;
            CreateCache(capacity);
            _cache.Size = 4;

            Assert.DoesNotThrow(() => _cache.Get(0));
            Assert.DoesNotThrow(() => _cache.Get(_cache.Size - 1));
            Assert.Throws<IndexOutOfRangeException>(() => _cache.Get(-1));
            Assert.Throws<IndexOutOfRangeException>(() => _cache.Get(_cache.Size));
        }

        private void CreateCache(int capacity)
        {
            _cache = new RaycastHitCache(capacity);
        }

        private void AssertSizeEqualsAfterSet(int size)
        {
            _cache.Size = size;
            Assert.AreEqual(_cache.Size, size);
        }
    }
}
