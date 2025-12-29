using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(string groupNumber)
        {
            manager.Navigator.GoToGroupsPage();
            RemoveGroup(groupNumber);
            ReturnToGroupsPage();
            return this;
        }

        internal GroupHelper Modify(GroupData group, string groupIndex)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupModify(groupIndex);
            FillGroupForm(group);
            SubmitGroupModify();
            ReturnToGroupsPage();
            return this;
        }

        private GroupHelper SubmitGroupModify()
        {
            driver.FindElement(By.Name("update")).Click();
            return this; ;
        }

        private GroupHelper InitGroupModify(string groupIndex)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + groupIndex + "]/input")).Click();
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper RemoveGroup(string indexGroup = "1")
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + indexGroup + "]/input")).Click();
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

       
    }
}
