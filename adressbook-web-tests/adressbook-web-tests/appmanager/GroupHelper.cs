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

        public GroupHelper CheckGroupList()
        {
            manager.Navigator.GoToGroupsPage();
            if (!IsElementPresent(By.XPath("//div[@id='content']/form/span[1]/input")))
            {
                manager.Groups.Create(new GroupData("Group_N"));
            }
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

        public List<GroupData> GetGropList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
        }
    }
}
