using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Drawing.Text;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserRemoveTests : AuthTestBase
    {
        [Test]
        public void UserRemoveTest()
        {
            app.Contacts.CheckUsersList();

            List<UserData> oldUsers = app.Contacts.GetUserList();

            app.Contacts.Remove("2");
            app.Navigator.GoToHomePage();

            List<UserData> newUsers = app.Contacts.GetUserList();
            oldUsers.RemoveAt(0);
            oldUsers.Sort();
            newUsers.Sort();
            Assert.AreEqual(oldUsers, newUsers);
        }
    }
}
