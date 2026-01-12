using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("group1");
            group.Header = "group1";
            group.Footer = "group1";

            List<GroupData> oldGroups = app.Groups.GetGropList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGropList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGropList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGropList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGropList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGropList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}
