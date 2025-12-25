using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using adressbook_web_tests;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemoveTests : TestBase
    {
        [Test]
        public void GroupRemoveTest()
        {
            app.Navigator.GoToGroupsPage();
            app.Groups
                .RemoveGroup("2")
                .ReturnToGroupsPage();
        }

    }
}
