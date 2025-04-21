using Twice_linear;

namespace Twice_linear___tests
{
    public class Tests
    {
        [Test]
        public static void test1()
        {
            testing(DoubleLinear.DblLinear(10), 22);
            testing(DoubleLinear.DblLinear(20), 57);
            testing(DoubleLinear.DblLinear(30), 91);
            testing(DoubleLinear.DblLinear(50), 175);
        }

        private static void testing(int actual, int expected)
        {
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}