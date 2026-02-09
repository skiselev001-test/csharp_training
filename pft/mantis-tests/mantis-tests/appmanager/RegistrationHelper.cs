using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccauntData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();


        }

       

        private void SubmitRegistration()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void FillRegistrationForm(AccauntData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

         private void OpenRegistrationForm()
        {
            driver.FindElements(By.CssSelector("a.back-to-login-link"))[0].Click();
        }
        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.28.0/login_page.php";
        }
    }
}
