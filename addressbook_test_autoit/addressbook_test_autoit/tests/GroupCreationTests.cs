using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_test_autoit
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData newGroup = new GroupData()
            {
                Name = "test"
            };

            app.Groups.Add(newGroup);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();
            
            Console.WriteLine("oldGroup - " + oldGroups.Count + "\r\n" + "newGroup - " + newGroups.Count + "\r\n");
            foreach (GroupData group in oldGroups) {
                Console.WriteLine("oldGroup - " + group.Name + "\r\n");
            }

            foreach (GroupData group in newGroups)
            {
                Console.WriteLine("newGroup - " + group.Name + "\r\n");
            }

            Assert.AreEqual(oldGroups.Count, newGroups.Count);

        }
    }
}
