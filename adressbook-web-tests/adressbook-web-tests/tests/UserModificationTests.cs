using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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
            ContactData userData = new ContactData("User_1", "User_lastname_01");
            userData.Bday = "17";
            userData.Bmonth = "January";
            userData.Byear = "2010";
            userData.Aday = "27";
            userData.Amonth = "January";
            userData.Ayear = "2010";
            app.Contacts.CheckUsersList();

            List<ContactData> oldUsers = app.Contacts.GetUserList();

            ContactData toBeModificated = oldUsers[0];

            app.Contacts.Modify(userData,0);
            app.Navigator.GoToHomePage();

            Assert.AreEqual(oldUsers.Count, app.Contacts.GetUserCount());

            List<ContactData> newUsers = app.Contacts.GetUserList();
            int userIdIsFint = 0;

            oldUsers[0].Firstname = userData.Firstname;
            oldUsers[0].Lastname = userData.Lastname;
            oldUsers.Sort();
            newUsers.Sort();
            Assert.AreEqual(oldUsers, newUsers);

            foreach (ContactData user in newUsers)
            {
                if (toBeModificated.Id == user.Id)
                {
                    userIdIsFint = 1;
                }
            }

            Assert.AreEqual(1, userIdIsFint);

            foreach (ContactData user in newUsers)
            {
                if (toBeModificated.Id == user.Id) 
                {
                    Assert.AreEqual(toBeModificated.Firstname, user.Firstname);
                    Assert.AreEqual(toBeModificated.Lastname, user.Lastname);
                }
            }
        }
    }
}
