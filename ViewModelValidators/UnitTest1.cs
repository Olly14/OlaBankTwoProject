using Bank.App.Models;
using NUnit.Framework;

namespace ViewModelValidators
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var appUser = new AppUserViewModel()
            {

            };
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}