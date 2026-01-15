using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Internal;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }

        public void Login(AccauntData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                
                Logout();
            }

            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public bool IsLoggedIn(AccauntData account)
        {
            return IsLoggedIn()
                && GetLoggetUserName() == account.Username;
              //  && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text == "(" + account.Username + ")";
             // && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text == System.String.Format("(${0})", account.Username);
        }

        private string GetLoggetUserName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }
    }
}
