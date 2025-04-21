using Twice_linear;

namespace Twice_linear___tests
{
    public class Tests
    {
        //[Test]
        //public static void Test1()
        //{
        //    Assert.That(DoubleLinear.DblLinear(10), Is.EqualTo(22));
        //}
        
        //[Test]
        //public static void Test2()
        //{
        //    Assert.That(DoubleLinear.DblLinear(20), Is.EqualTo(57));
        //}
        
        //[Test]
        //public static void Test3()
        //{
        //    Assert.That(DoubleLinear.DblLinear(30), Is.EqualTo(91));
        //}
        
        //[Test]
        //public static void Test4()
        //{
        //    Assert.That(DoubleLinear.DblLinear(50), Is.EqualTo(175));
        //}


        [TestCase(10, 22)]
        [TestCase(20, 57)]
        [TestCase(30, 91)]
        [TestCase(50, 175)]
        public static void Test(int actual, int expected)
        {
            Assert.That(DoubleLinear.DblLinear(actual), Is.EqualTo(expected));
        }
    }
}