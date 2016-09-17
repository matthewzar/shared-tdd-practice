using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDPractice;

namespace TDDPractice_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(0, SimpleStringParsing.StringToInt("0"), 0,"zero basecase");
        }
    }
}
