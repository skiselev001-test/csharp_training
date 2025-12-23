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
            OpenHomePage();
            Login(new AccauntData("admin", "secret"));
            GoToGroupsPage();
            RemoveGroup("2");
            ReturnToGroupsPage();
            Logout();
        }

    }
}
