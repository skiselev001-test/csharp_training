using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using adressbook_web_tests;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemoveTests : AuthTestBase
    {
        [Test]
        public void GroupRemoveTest()
        {
            app.Groups.Remove("2");
        }

    }
}
