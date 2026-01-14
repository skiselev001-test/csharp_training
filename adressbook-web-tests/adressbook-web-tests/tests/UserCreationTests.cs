using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
            UserData userData = new UserData("User1", "User1_lastname");
            userData.Middlename = "User1_middlename";
            userData.Bday = "17";
            userData.Bmonth = "January";
            userData.Byear = "2010";
            userData.Aday = "27";
            userData.Amonth = "January";
            userData.Ayear = "2010";

            List<UserData> oldUsers = app.Contacts.GetUserList();
            
            app.Contacts.Create(userData);
            app.Navigator.GoToHomePage();

            Assert.AreEqual(oldUsers.Count + 1, app.Contacts.GetUserCount());

            List<UserData> newUsers = app.Contacts.GetUserList();
            oldUsers.Add(userData);
            oldUsers.Sort();
            newUsers.Sort();
            Assert.AreEqual(oldUsers, newUsers);
          //  foreach (UserData user in oldUsers)
          //  {
          //      Console.WriteLine($"{user.Firstname} {user.Lastname}");
          //  }
        }

        
    }
}
