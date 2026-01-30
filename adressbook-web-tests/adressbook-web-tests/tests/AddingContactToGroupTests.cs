using NUnit.Framework;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void AddingContactToGroupTest()
        {
            app.Groups.GroupPresence();
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            app.Contacts.ContactPresence(group);
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
