using Core;
using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class EmployeeViewModelTests
    {
        [TestMethod]
        public void SalaryColorIsRedByDefaultTest() {
            var o = new EmployeeViewModel(null, "Admin");
            Assert.AreEqual("red", o.SalaryColor);
        }
        [TestMethod]
        public void SalaryColorIsRedIfSetColorArgumentIsNullTest()
        {
            var o = new EmployeeViewModel(null, "Admin");
            o.setColor(null);
            Assert.AreEqual("red", o.SalaryColor);
        }
        [TestMethod]
        public void SalaryColorIsYellowForHighSalariesTest()
        {
            var o = new EmployeeViewModel(null, "Admin");
            o.setColor(new Employee(null, null, 15000));
            Assert.AreEqual("green", o.SalaryColor);
        }
        [TestMethod]
        public void SalaryColorIsGreenForSmallSalariesTest()
        {
            var o = new EmployeeViewModel(null, "Admin");
            o.setColor(new Employee(null, null, 15001));
            Assert.AreEqual("yellow", o.SalaryColor);
        }
    }
}
