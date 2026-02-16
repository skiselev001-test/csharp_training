using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Internal;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class AdminHelper : HelperBase
    {
        private string baseUrl;

        public AdminHelper(ApplicationManager manager, String baseUrl) : base (manager) 
        {
         this.baseUrl = baseUrl;
        }

        public List<AccountData> GetAllAccounts()
        {
            List<AccountData> accounts = new List<AccountData>();
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_page.php";
            IList<IWebElement> rows = driver.FindElements(By.CssSelector("table.table>tbody tr"));
            foreach (IWebElement row in rows)
            {
                IWebElement link = row.FindElement(By.TagName("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+(?=\D*$)");
                string id = m.Value;

                accounts.Add(new AccountData ()
                {
                    Name = name,
                    Id = id
                });
            }
            //driver.Quit();

            return accounts;
        }

        public void DeleteAccount(AccountData account)
        {
            //IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_edit_page.php?user_id=" + account.Id;
            driver.FindElement(By.XPath("//button[contains(text(), 'Delete')]")).Click();
            driver.FindElement(By.CssSelector("input[value='Delete Account']")).Click();
        }

        private IWebDriver OpenAppAndLogin()
        {
            //IWebDriver driver = new FirefoxDriver();
            driver.Url = baseUrl + "/login_page.php";
            driver.FindElement(By.Name("username")).SendKeys("administrator");
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
            driver.FindElement(By.Name("password")).SendKeys("root");
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
            return driver;
        }
    }
}
