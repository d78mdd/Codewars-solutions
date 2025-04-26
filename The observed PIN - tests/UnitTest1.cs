using The_observed_PIN;

namespace The_observed_PIN___tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void TestBasic1()
        {
            Dictionary<string, string[]> pin = new Dictionary<string, string[]>{
                { "8", new[] { "5", "7", "8", "9", "0" } },
            };

            Assert.That(Kata.GetPINs(pin.ElementAt(0).Key), Is.EquivalentTo(pin.ElementAt(0).Value), "PIN: " + pin);
        }

        [Test]
        public void TestBasic2()
        {
            Dictionary<string, string[]> pin = new Dictionary<string, string[]>{
                { "11", new[] { "11", "22", "44", "12", "21", "14", "41", "24", "42" } },
            };

                Assert.That(Kata.GetPINs(pin.ElementAt(0).Key), Is.EquivalentTo(pin.ElementAt(0).Value), "PIN: " + pin);
        }

        [Test]
        public void TestBasic3()
        {
            Dictionary<string, string[]> pin = new Dictionary<string, string[]>{
                { "369", new[] { "339", "366", "399", "658", "636", "258", "268", "669", "668", "266", "369", "398", "256", "296", "259", "368", "638", "396", "238", "356", "659", "639", "666", "359", "336", "299", "338", "696", "269", "358", "656", "698", "699", "298", "236", "239" } }
            };

            Assert.That(Kata.GetPINs(pin.ElementAt(0).Key), Is.EquivalentTo(pin.ElementAt(0).Value), "PIN: " + pin);
        }

    }
}