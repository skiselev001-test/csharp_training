using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using adressbook_web_tests;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemoveTests : AuthTestBase
    {
        [Test]
        public void GroupRemoveTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGropList();

            app.Groups.CheckGroupList();
            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGropList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

        }

    }
}
