using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        [OneTimeSetUp]
        public void InitiApplicationManager()
        {

            ApplicationManager app = ApplicationManager.GetIstatnce();
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccauntData("admin", "secret"));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            try
            {
                ApplicationManager.GetIstatnce().Driver.Quit();
 //               driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}
