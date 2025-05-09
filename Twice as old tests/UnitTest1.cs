using Twice_as_old;

namespace Twice_as_old_tests
{
    public class Tests
    {
        [Test]
        public void SampleTests()
        {
            Assert.That(TwiceAsOldSolution.TwiceAsOld(30, 0), Is.EqualTo(30));
            Assert.That(TwiceAsOldSolution.TwiceAsOld(30, 7), Is.EqualTo(16));
            Assert.That(TwiceAsOldSolution.TwiceAsOld(45, 30), Is.EqualTo(15));
        }

    }
}