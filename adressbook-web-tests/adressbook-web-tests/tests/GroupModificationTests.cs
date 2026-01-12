using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("group1");
            group.Header = "newgroup1";
            group.Footer = "newgroup1";

            app.Groups.CheckGroupList();
            app.Groups.Modify(group, 0);
        }
    }
}
