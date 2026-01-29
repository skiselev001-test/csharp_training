using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("group1");
            newData.Header = "newgroup1";
            newData.Footer = "newgroup1";

            app.Groups.CheckGroupList();
            //List<GroupData> oldGroups = app.Groups.GetGropList();
            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData groupToBeModificated = oldGroups[0];

            app.Groups.Modify(newData, groupToBeModificated);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            //List<GroupData> newGroups = app.Groups.GetGropList();
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if ( group.Id == groupToBeModificated.Id )
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }

 //           app.Groups.CheckGroupList();
  //          app.Groups.Modify(group, 0);
        }
    }
}
