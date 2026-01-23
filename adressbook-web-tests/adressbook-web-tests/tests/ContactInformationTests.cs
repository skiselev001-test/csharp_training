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
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }
    

        [Test]
        public void TestContactInformationFromPropertyForm()
        {
            ContactData fromEditForm = app.Contacts.GetInformationFromEditForm(0);
            String fromPropertyForm = app.Contacts.GetInformationPropertyForm(0);
            string fromEditFormAllFields = fromEditForm.AllFields;

            Assert.AreEqual(fromPropertyForm, fromEditForm.AllFields);
           // Assert.AreEqual(Regex.Replace(fromEditForm.AllFields, "[ ()HMW:\bomepage\b\\r\\n-]", ""), 
           //     Regex.Replace(fromPropertyForm, "[ ()HMW:\bomepage\b\\r\\n-]", ""));
        }
    }
}
