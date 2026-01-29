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
            GroupData group = GroupData.GetAll()[1];
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
