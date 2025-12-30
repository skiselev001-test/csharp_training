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
    public class UserModificationTests : AuthTestBase
    {
        [Test]
        public void UserModificationTest()
        {
            UserData userData = new UserData("User_1", "User_1");
            userData.Bday = "17";
            userData.Bmonth = "January";
            userData.Byear = "2010";
            userData.Aday = "27";
            userData.Amonth = "January";
            userData.Ayear = "2010";
            app.Contacts.CheckUsersList();
            app.Contacts.Modify(userData,"2");
            app.Navigator.GoToHomePage();
        }
    }
}
