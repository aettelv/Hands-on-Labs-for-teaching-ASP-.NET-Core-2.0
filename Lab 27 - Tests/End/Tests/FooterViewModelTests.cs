using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class FooterViewModelTests
    {
        private FooterViewModel o;

        [TestInitialize]
        public void TestInitialize()
        {
            o = new FooterViewModel(null);
        }
        [TestMethod]
        public void CompanyNameTest()
        {
            o.setCompanyName("TTÜ");
            Assert.AreEqual("TTÜ", o.CompanyName);
        }
        [TestMethod]
        public void YearTest()
        {
            Assert.AreEqual(DateTime.Now.Year.ToString(), o.Year);
        }
    }
}
