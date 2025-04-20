using Sort_binary_tree_by_levels;

namespace Sort_binary_tree_by_levels___tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test, Order(1)]
        public void NullTest()
        {
            Assert.That(Kata.TreeByLevels(null), Is.EqualTo(new List<int>()));
        }

        [Test, Order(2)]
        public void BasicTest()
        {
            var expectedList = new List<int>() { 1, 2, 3, 4, 5, 6 };
            Assert.That(Kata.TreeByLevels(new Node(new Node(null, new Node(null, null, 4), 2), new Node(new Node(null, null, 5), new Node(null, null, 6), 3), 1)), Is.EqualTo(expectedList));
        }

    }
}