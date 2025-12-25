using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ContactHelper Modify(UserData userData, string userIndex)
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
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(user.Firstname);
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(user.Middlename);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(user.Lastname);
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
            driver.FindElement(By.Name("ayear")).SendKeys(user.Ayear);
            return this;
        }

        public ContactHelper SubmitUserCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[19]")).Click();
            return this;
        }

        public ContactHelper SubmitUserModify()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
            return this;
        }

        private ContactHelper SelectUserToModify(string userIndex)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + userIndex + "]/td[8]/a/img")).Click();
            driver.FindElement(By.XPath("//form[@action='edit.php']")).Click();
            return this;
        }

        private ContactHelper SubmitUserRemove()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        private ContactHelper SelectUserToRemove(string userIndex)
        {
            driver.FindElement(By.Id(userIndex)).Click();
            return this;
        }
    }
}
