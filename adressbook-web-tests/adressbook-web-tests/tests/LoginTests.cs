using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            app.Auth.Logout();

            AccauntData account = new AccauntData("admin", "secret");
            app.Auth.Login(account);

            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInValidCredentials()
        {
            app.Auth.Logout();

            AccauntData account = new AccauntData("admin", "12345");
            app.Auth.Login(account);

            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
