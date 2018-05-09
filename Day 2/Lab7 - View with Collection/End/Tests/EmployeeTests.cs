using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void FirstNameTest()
        {
            Employee e = new Employee("eesnimi", null, 0);
            Assert.AreEqual("eesnimi", e.FirstName);
        }
    }
}
