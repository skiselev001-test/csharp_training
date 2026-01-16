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

        public ContactHelper Create(ContactData userData)
        {
            manager.Navigator.GoToUserPage();
            FillUserForm(userData);
            SubmitUserCreation();
            return this;
        }

        public ContactHelper Modify(ContactData userData, int userIndex)
        {
            SelectUserToModify(userIndex);
            FillUserForm(userData);
            SubmitUserModify();
            return this;
        }

        public ContactHelper Remove(int userIndex)
        {
            SelectUserToRemove(userIndex);
            SubmitUserRemove();
            return this;
        }

        public ContactHelper FillUserForm(ContactData user)
        {
            Type(By.Name("firstname"), user.Firstname);
            Type(By.Name("middlename"), user.Middlename);
            Type(By.Name("lastname"), user.Lastname);
            Type(By.Name("address"), user.Address);
            Type(By.Name("home"), user.HomePhone);
            Type(By.Name("mobile"), user.MobilePhone);
            Type(By.Name("work"), user.WorkPhone);
            Type(By.Name("email"), user.Email);
            Type(By.Name("email2"), user.Email2);
            Type(By.Name("email3"), user.Email3);

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
                manager.Contacts.Create(new ContactData("User_N","User_N"));
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

        private ContactHelper SelectUserToRemove(int userIndex)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (userIndex+2) + "]/td/input")).Click(); 
            return this;
        }

        private List<ContactData> userCache = null;

        public List<ContactData> GetUserList()
        {
            if (userCache == null)
            {
                userCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("[name=\"entry\"]"));
                foreach (IWebElement element in elements)
                {
                    IWebElement firstname = element.FindElement(By.CssSelector("td:nth-child(3)"));
                    IWebElement lastname = element.FindElement(By.CssSelector("td:nth-child(2)"));
                    userCache.Add(new ContactData(firstname.Text, lastname.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("Id")
                    });
                }
            }
                return new List<ContactData>(userCache);
        }

        public int GetUserCount()
        {
            return driver.FindElements(By.CssSelector("table#maintable tbody tr")).Count-1;
        }

        internal ContactData GetInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allEmails = cells[4].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };

        }

        internal ContactData GetInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            manager.Contacts.SelectUserToModify(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("Value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("Value");
            string address = driver.FindElement(By.Name("address")).Text;

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("Value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("Value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("Value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("Value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("Value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("Value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3

            };
        }

        internal ContactData GetInformationPropertyForm(int index)
        {
            manager.Navigator.OpenHomePage();
            manager.Contacts.SelectUserProperty(index);

            // IList<IWebElement> cells = driver.FindElements(By.CssSelector("body div#content")).;
            //IList<IWebElement> cells = driver.FindElement(By.Id("content")).FindElements(By.TagName("br"));
            IWebElement element = driver.FindElement(By.Id("content"));
            string[] allName = element.FindElement(By.CssSelector("b")).Text.Split(' ');
            string firstName = allName[0];
            string middleName = allName[1];
            string lastName = allName[2];
            
            // string address = driver.FindElement(By.XPath("//div[@id=\"content\"]/br/following-sibling::text()")).Text;
            // string mobilePhone = element.FindElements(By.TagName("br"))[3].Text; ;
            // string homePhone = element.FindElements(By.TagName("br"))[2].Text;
            // string workPhone = element.FindElements(By.TagName("br"))[4].Text;
            IList<IWebElement> emailElements = element.FindElements(By.CssSelector("a"));
            List<string> emails = new List<string>();
            foreach (IWebElement email in emailElements)
            {
                if (emailElements != null)
                {
                    emails.Add(email.Text);
                    System.Console.Out.Write(email.Text);

                }
            }
           
            
            //string email2 = element.FindElements(By.TagName("br"))[7].FindElement(By.TagName("a")).Text;
            //string email3 = element.FindElements(By.TagName("br"))[8].FindElement(By.TagName("a")).Text;
            //string[] allEmails = element.FindElements(By.TagName("a")).T;

            /*string allName = driver.FindElement(By.CssSelector("body div#content>b")).Text;
            string address = driver.FindElement(By.CssSelector("body div#content>br")).Text;
            //string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("Value");
            //string address = driver.FindElement(By.Name("address")).Text;

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("Value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("Value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("Value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("Value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("Value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("Value"); */



            return new ContactData(firstName, lastName)
            {
                Middlename = middleName,
                //Address = address,
              //  HomePhone = homePhone,
               // MobilePhone = mobilePhone,
               // WorkPhone = workPhone,
                Email = emails[0],
                Email2 = emails[1],
                Email3 = emails[2],
                Homepage = emails[3]

            };
        }

        private ContactHelper SelectUserProperty(int index)
        {
            driver.FindElement(By.CssSelector("table#maintable tr:nth-child(" + (index + 2) + ") td:nth-child(1)")).Click();    
            driver.FindElement(By.CssSelector("table#maintable tr:nth-child(" + (index + 2) + ") td:nth-child(7)>a")).Click();
            return this;
        }
    }
}
//ICollection<IWebElement> elementsFirstname = driver.FindElements(By.CssSelector("[name=\"entry\"]>td:nth-child(3)"));