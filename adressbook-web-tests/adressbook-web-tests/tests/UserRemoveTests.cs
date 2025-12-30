using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Drawing.Text;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserRemoveTests : AuthTestBase
    {
        [Test]
        public void UserRemoveTest()
        {
            app.Contacts.Remove("2");
            app.Navigator.GoToHomePage();
        }
    }
}
