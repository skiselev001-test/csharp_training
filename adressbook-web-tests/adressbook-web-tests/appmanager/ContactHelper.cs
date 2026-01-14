using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager) 
        {
        }

        public ContactHelper Create(UserData userData)
        {
            manager.Navigator.GoToUserPage();
            FillUserForm(userData);
            SubmitUserCreation();
            return this;
        }

        public ContactHelper Modify(UserData userData, int userIndex)
        {
            SelectUserToModify(userIndex);
            FillUserForm(userData);
            SubmitUserModify();
            return this;
        }

        public ContactHelper Remove(string userIndex)
        {
            SelectUserToRemove(userIndex);
            SubmitUserRemove();
            return this;
        }

        public ContactHelper FillUserForm(UserData user)
        {
            Type(By.Name("firstname"), user.Firstname);
            Type(By.Name("middlename"), user.Middlename);
            Type(By.Name("lastname"), user.Lastname);

         /*  locators to work in future
          
            driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(user.Nickname);
            driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(user.Title);
            driver.FindElement(By.Name("company")).Click();
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(user.Company);
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(user.Address);
            driver.FindElement(By.Name("home")).Click();
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(user.Home);
            driver.FindElement(By.Name("mobile")).Click();
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(user.Mobile);
            driver.FindElement(By.Name("work")).Click();
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(user.Work);
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(user.Email);
            driver.FindElement(By.Name("email2")).Click();
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(user.Email2);
            driver.FindElement(By.Name("email3")).Click();
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(user.Email3);
            driver.FindElement(By.Name("homepage")).Click();
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(user.Homepage);
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(user.Bday);
            driver.FindElement(By.XPath("//option[@value=" + user.Bday + "]")).Click();
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(user.Bmonth);
            driver.FindElement(By.XPath("//option[@value='January']")).Click();
            //driver.FindElement(By.XPath("//option[@value=" + user.Bmonth + "]")).Click();
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(user.Byear);
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(user.Aday);
            driver.FindElement(By.XPath("//div[@id='content']/form/select[3]/option[29]")).Click();
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(user.Amonth);
            driver.FindElement(By.XPath("//div[@id='content']/form/select[4]/option[2]")).Click();
            driver.FindElement(By.Name("ayear")).Click();
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys(user.Ayear); */

            return this;
        }

        public ContactHelper CheckUsersList()
        {
            manager.Navigator.OpenHomePage();
            if (!IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr/td/a/img[@title='Edit']")))
            {
                manager.Contacts.Create(new UserData("User_N","User_N"));
                manager.Navigator.GoToHomePage();
            }
            return this;
        }

        public ContactHelper SubmitUserCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[19]")).Click();
            userCache = null;
            return this;
        }

        public ContactHelper SubmitUserModify()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
            userCache = null;
            return this;
        }

        private ContactHelper SelectUserToModify(int userIndex)
        {
            driver.FindElement(By.CssSelector("table#maintable tr:nth-child("+(userIndex+2)+") td:nth-child(1)")).Click();     //By.XPath("//table[@id='maintable']/tbody/tr[" + userIndex + "]/td[8]/a/img")).Click();
            driver.FindElement(By.CssSelector("table#maintable tr:nth-child("+(userIndex+2)+") td:nth-child(8) ")).Click();
            driver.FindElement(By.XPath("//form[@action='edit.php']")).Click();
            return this;
        }

        private ContactHelper SubmitUserRemove()
        {
            driver.FindElement(By.Name("delete")).Click();
            userCache = null;
            return this;
        }

        private ContactHelper SelectUserToRemove(string userIndex)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + userIndex + "]/td/input")).Click(); 
            return this;
        }

        private List<UserData> userCache = null;

        public List<UserData> GetUserList()
        {
            if (userCache == null)
            {
                userCache = new List<UserData>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("[name=\"entry\"]"));
                foreach (IWebElement element in elements)
                {
                    IWebElement firstname = element.FindElement(By.CssSelector("td:nth-child(3)"));
                    IWebElement lastname = element.FindElement(By.CssSelector("td:nth-child(2)"));
                    userCache.Add(new UserData(firstname.Text, lastname.Text));
                }
            }
                return new List<UserData>(userCache);
        }

        public int GetUserCount()
        {
            return driver.FindElements(By.CssSelector("table#maintable tbody tr")).Count-1;
        }
    }
}
//ICollection<IWebElement> elementsFirstname = driver.FindElements(By.CssSelector("[name=\"entry\"]>td:nth-child(3)"));