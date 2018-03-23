using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace OPIS
{
    [TestFixture]
    class UnitTest
    {
        [Test]
        public void TestProduct_Equals_AssertTrue()
        {
            Product p = new Product("Test", "0001", 1.2, 10);
            bool result = p.equals(new Product("T", "0001", 1.2, 10));
            Assert.IsTrue(result);
        }

        [Test]
        public void TestProduct_Equals_AssertFalse()
        {
            Product p = new Product("Test", "0001", 1.2, 10);
            bool result = p.equals(new Product("T", "1000", 1.2, 10));
            Assert.IsFalse(result);
        }
    }
}
