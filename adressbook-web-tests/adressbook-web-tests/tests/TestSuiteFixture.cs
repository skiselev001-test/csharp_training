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

            ApplicationManager app = ApplicationManager.GetInstance();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            try
            {
                ApplicationManager.GetInstance().Driver.Quit();
 //               driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}
