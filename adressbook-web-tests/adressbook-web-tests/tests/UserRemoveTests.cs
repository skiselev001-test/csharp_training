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
    public class UserRemoveTests : UserTestBase
    {
        [Test]
        public void UserRemoveTest()
        {
            app.Contacts.CheckUsersList();

            // List<ContactData> oldUsers = app.Contacts.GetUserList();
            List<ContactData> oldUsers = ContactData.GetAll();

            ContactData toBeRemoved = oldUsers[0];

            app.Contacts.Remove(toBeRemoved);
            app.Navigator.GoToHomePage();

            Assert.AreEqual(oldUsers.Count - 1, app.Contacts.GetUserCount());

            //List<ContactData> newUsers = app.Contacts.GetUserList();
            List<ContactData> newUsers = ContactData.GetAll();
            oldUsers.RemoveAt(0);
            oldUsers.Sort();
            newUsers.Sort();
            Assert.AreEqual(oldUsers, newUsers);

            foreach (ContactData user in newUsers)
            {
                Assert.AreNotEqual(toBeRemoved.Id, user.Id);
            }
        }
    }
}
