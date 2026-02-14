using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
            String url = GetConfirmationUrl(account);
            FillPasswordForm(url, account);
            SubmitPasswordForm();
            OpenMainPage();
            Assert.IsTrue(Login(account));

        }

        public void CheckExistAccount(AccountData account)
        {
            OpenMainPage();
            if (Login(account))
            {
                Random rnd = new Random();
                int randomNumber = rnd.Next(1, 1001);
                account.Name = account.Name + randomNumber.ToString();
                account.Email = account.Name + "@localhost.localdomain";
                driver.FindElement(By.CssSelector("span.user-info")).Click();
                driver.FindElement(By.XPath("//i[@class='fa fa-sign-out ace-icon']/..")).Click();
            }
        }

        private string GetConfirmationUrl(AccountData account)
        {
            String message = manager.Mail.GetLastMail(account);
            Match match = Regex.Match(message, @"http://\S*");
            return match.Value;
        }

        private void FillPasswordForm(string url, AccountData account)
        {
            driver.Url = url;
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.Name("password_confirm")).SendKeys(account.Password);
            
        }

        private void SubmitPasswordForm()
        {
            driver.FindElement(By.CssSelector("button[type=\"submit\"]")).Click();
        }

        private void SubmitRegistration()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

         private void OpenRegistrationForm()
        {
            driver.FindElements(By.CssSelector("a.back-to-login-link"))[0].Click();
        }
        public void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.28.0/login_page.php";
        }

        internal bool Login(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            if (driver.FindElements(By.CssSelector("i.fa-gears")).Count > 0)
            {
                driver.FindElement(By.CssSelector("i.fa-gears")).Click(); 
            }
            if (driver.FindElements(By.XPath("//p[contains(text(),'blocked')]")).Count > 0) 
            {
                return false;
            }
            return true;
        }
    }
}
