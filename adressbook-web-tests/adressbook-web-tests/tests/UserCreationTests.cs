using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserCreationTests : AuthTestBase
    {
        [Test]
        public void UserCreationTest()
        {
            UserData userData = new UserData("User1", "User1");
            userData.Bday = "17";
            userData.Bmonth = "January";
            userData.Byear = "2010";
            userData.Aday = "27";
            userData.Amonth = "January";
            userData.Ayear = "2010";
            app.Contacts.Create(userData);
            app.Navigator.GoToHomePage();
        }

        
    }
}
