using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample.Dal;
using System.Linq;

namespace UnitTest.Sample
{
    [TestClass]
    public class UnitTest1
    {
        EmployeeDal emp;
        public UnitTest1()
        {
             emp = new EmployeeDal("");
        }

        [TestMethod]
        public void TestMethod1()
        {
            var data = emp.GetAll().ToList();

            Assert.IsTrue(data.Count()>0);
        }
    }
}
