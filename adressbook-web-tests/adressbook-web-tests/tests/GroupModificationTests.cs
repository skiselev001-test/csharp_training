using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("group1");
            newData.Header = "newgroup1";
            newData.Footer = "newgroup1";

            app.Groups.CheckGroupList();
            List<GroupData> oldGroups = app.Groups.GetGropList();

            GroupData oldData = oldGroups[0];

            app.Groups.Modify(newData, 0);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGropList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if ( group.Id == oldData.Id )
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }

 //           app.Groups.CheckGroupList();
  //          app.Groups.Modify(group, 0);
        }
    }
}
