using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace adressbook_web_tests
{
    [TestClass]
    public class UnitTest_1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Square_1 s1 = new Square_1(5);
            Square_1 s2 = new Square_1(10);
            Square_1 s3 = s1;

            Assert.AreEqual(s1.getSize(), 5);
            Assert.AreEqual(s2.getSize(), 10);
            Assert.AreEqual(s3.getSize(), 5);

            s3.setSize(15);

            Assert.AreEqual(s1.getSize(), 15);
        }
    }
}
