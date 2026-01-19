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
        public static IEnumerable<ContactData> RandomGroupDataProvider()
        {
            List<ContactData> users = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                users.Add(new ContactData(GenerateRandomString(20), GenerateRandomString(20))
                {
                    Middlename = GenerateRandomString(10),
                    Address = GenerateRandomString(10),
                    Email = GenerateRandomString(10),
                    Email2 = GenerateRandomString(10),
                    Email3 = GenerateRandomString(10),
                    HomePhone = "(000)-1212-1212",
                    MobilePhone = "(000)-1212-333",
                    WorkPhone = "(000)-1212-44444",
                    Bday = "17",
                    Bmonth = "January",
                    Byear = "2010",
                    Aday = "27",
                    Amonth = "January",
                    Ayear = "2010"
                });

            }
            return users;
        }
        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void UserCreationTest(ContactData userData)
        {
            /*ContactData userData = new ContactData("User1", "User1_lastname");
            userData.Middlename = "User1_middlename";
            userData.Address = "TTbb";
            userData.Email = "test@test";
            userData.Email2 = "test2@test";
            userData.Email3 = "test3@test";
            userData.HomePhone = "(000)-1212-1212";
            userData.MobilePhone = "(000)-1212-333";
            userData.WorkPhone = "(000)-1212-44444";
            userData.Bday = "17";
            userData.Bmonth = "January";
            userData.Byear = "2010";
            userData.Aday = "27";
            userData.Amonth = "January";
            userData.Ayear = "2010";*/

            List<ContactData> oldUsers = app.Contacts.GetUserList();
            
            app.Contacts.Create(userData);
            app.Navigator.GoToHomePage();

            Assert.AreEqual(oldUsers.Count + 1, app.Contacts.GetUserCount());

            List<ContactData> newUsers = app.Contacts.GetUserList();
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
