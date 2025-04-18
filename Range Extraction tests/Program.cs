using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using Range_Extraction;

namespace Range_Extraction_tests
{
    [TestFixture]
    public class Program
    {

        [Test]
        public void SimpleTests1()
        {
            Assert.That(Range_Extraction.Program.Extract(new[] { 1, 2 }), Is.EqualTo("1,2"));
        }

        [Test]
        public void SimpleTests2()
        {
            Assert.That(Range_Extraction.Program.Extract(new[] { 1, 2, 3 }), Is.EqualTo("1-3"));
        }

        [Test]
        public void SimpleTests3()
        {
            Assert.That(Range_Extraction.Program.Extract(new[] { 1 }), Is.EqualTo("1"));
        }

        [Test]
        public void SimpleTests4()
        {
            Assert.That(Range_Extraction.Program.Extract(new[] { -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20 }), Is.EqualTo("-6,-3-1,3-5,7-11,14,15,17-20"));
        }

        [Test]
        public void SimpleTests5()
        {
            Assert.That(Range_Extraction.Program.Extract(new[] { -3, -2, -1, 2, 10, 15, 16, 18, 19, 20 }), Is.EqualTo("-3--1,2,10,15,16,18-20"));
        }

        [Test]
        public void SimpleTests6()
        {
            Assert.That(Range_Extraction.Program.Extract(new[] { 35, 37, 38, 39, 41, 43, 45, 47, 49, 51, 52, 53, 55, 57, 59, 60, 62, 63, 64, 65, 67, 69, 70, 71, 73 }), Is.EqualTo("35,37-39,41,43,45,47,49,51-53,55,57,59,60,62-65,67,69-71,73"));
        }

        [Test]
        public void SimpleTests7()
        {
            Assert.That(Range_Extraction.Program.Extract(new[] { -109, -108, -106, -104, -103, -101, -100, -98, -97, -96, -94, -92, -91 }), Is.EqualTo("-109,-108,-106,-104,-103,-101,-100,-98--96,-94,-92,-91"));
        }

    }
}
