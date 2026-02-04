using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupDeletionTests : TestBase
    {
        [Test]
        public void TestGroupDeletion()
        {
            /*
            app.Groups.CheckGroupList();

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            string groupIndex = "#0|#0";
            
            app.Groups.Del(groupIndex);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();

            Console.WriteLine("oldGroup - " + oldGroups.Count + "\r\n" + "newGroup - " + newGroups.Count + "\r\n");
            foreach (GroupData group in oldGroups)
            {
                Console.WriteLine("oldGroup - " + group.Name + "\r\n");
            }

            foreach (GroupData group in newGroups)
            {
                Console.WriteLine("newGroup - " + group.Name + "\r\n");
            }

            Assert.AreEqual(oldGroups.Count, newGroups.Count);
            */
        }
    }
}

