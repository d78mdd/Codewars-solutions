using Square_into_Squares._Protect_trees;

namespace Square_into_Squares._Protect_trees_tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void Test1()
        {
            Program p = new Program();
            long n = 11;
            Assert.That(p.decompose(n), Is.EqualTo("1 2 4 10"));
        }

    }
}