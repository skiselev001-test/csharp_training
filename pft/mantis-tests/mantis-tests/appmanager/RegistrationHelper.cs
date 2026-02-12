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

        public void Register(AccauntData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
            String url = GetConfirmationUrl(account);
            FillPasswordForm(url, account);
            SubmitPasswordForm();

        }

        private string GetConfirmationUrl(AccauntData account)
        {
            String message = manager.Mail.GetLastMail(account);
            Match match = Regex.Match(message, @"http://\S*");
            return match.Value;
        }

        private void FillPasswordForm(string url, AccauntData account)
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

        private void FillRegistrationForm(AccauntData account)
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

        internal void Login(AccauntData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            driver.FindElement(By.CssSelector("i.fa-gears")).Click();
        }
    }
}
