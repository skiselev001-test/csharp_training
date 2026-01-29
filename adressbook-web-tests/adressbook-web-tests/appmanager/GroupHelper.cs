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

        public GroupHelper Remove(int groupNumber)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(groupNumber);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(GroupData toBeRemoved)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(toBeRemoved.Id);
            RemoveGroup();
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

        public GroupHelper Modify(GroupData group, int groupIndex)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupModify(groupIndex);
            FillGroupForm(group);
            SubmitGroupModify();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper Modify(GroupData group, GroupData groupToBeModificated)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupModify(groupToBeModificated.Id);
            FillGroupForm(group);
            SubmitGroupModify();
            ReturnToGroupsPage();
            return this;
        }

        

        private GroupHelper SubmitGroupModify()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this; ;
        }

        private GroupHelper InitGroupModify(int groupIndex)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (groupIndex +1) + "]/input")).Click();
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        private GroupHelper InitGroupModify(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
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

        public GroupHelper SelectGroup(int indexGroup = 0)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (indexGroup + 1) + "]/input")).Click();
            return this;
        }

        public GroupHelper SelectGroup(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }


        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGropList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();

                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text) {
                        Id = element.FindElement(By.TagName("Input")).GetAttribute("value")
                    });
                }
            }

            return new List<GroupData>(groupCache);
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

       
    }
}
