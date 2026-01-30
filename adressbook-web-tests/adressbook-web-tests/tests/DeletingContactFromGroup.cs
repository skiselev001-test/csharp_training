using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class DeletingContactFromGroupTests : AuthTestBase
    {
        [Test]

        public void DeletingContactFromGroupTest()
        {
            app.Groups.GroupPresence();
            GroupData group = GroupData.GetAll()[0];
            app.Contacts.ContactPresenceFor(group);
            List<ContactData> oldList = group.GetContacts();
            ContactData contactToDelete = oldList[0];

            app.Contacts.DeleteContactFromGroup(contactToDelete, group);

            List<ContactData> newList = group.GetContacts();
            newList.Add(contactToDelete);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
