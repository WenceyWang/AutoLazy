﻿using System;
using System.Linq;
using NUnit.Framework;

namespace AutoLazy.Tests
{
    [TestFixture]
    public class InstanceRefTypeTests
    {
        private int _getStringCount;
        private int _stringPropCount;

        [Lazy]
        public string GetString()
        {
            ++_getStringCount;
            return Guid.NewGuid().ToString("n");
        }

        [Lazy]
        public string StringProp
        {
            get
            {
                ++_stringPropCount;
                return Guid.NewGuid().ToString("n");
            }
        }

        [Test]
        public void GetString_should_be_lazy()
        {
            Assert.AreEqual(0, _getStringCount);
            var first = GetString();
            Assert.AreEqual(1, _getStringCount);
            var second = GetString();
            Assert.AreEqual(1, _getStringCount);
            Assert.AreEqual(first, second);
        }

        [Test]
        public void StringProp_should_be_lazy()
        {
            Assert.AreEqual(0, _stringPropCount);
            var first = StringProp;
            Assert.AreEqual(1, _stringPropCount);
            var second = StringProp;
            Assert.AreEqual(1, _stringPropCount);
            Assert.AreEqual(first, second);
        }
    }

}