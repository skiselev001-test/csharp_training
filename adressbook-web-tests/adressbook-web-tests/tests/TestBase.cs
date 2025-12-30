using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using WebAddressbookTests;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }
    }
}
