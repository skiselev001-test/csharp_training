using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace mantis_tests
{
    [TestFixture]
    public class UnitTest1 : TestBase
    {

        [Test]
        public void TestMethod1()
        {
            AccountData accaunt = new AccountData()
            {
                Name = "xxx",
                Password = "yyy"
            };
            Assert.IsFalse(app.James.Verify(accaunt));
            app.James.Add(accaunt);
            Assert.IsTrue(app.James.Verify(accaunt));
            app.James.Delete(accaunt);
            Assert.IsFalse(app.James.Verify(accaunt));
        }
    }
}
