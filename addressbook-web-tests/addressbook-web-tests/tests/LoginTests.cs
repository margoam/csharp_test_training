using System;
namespace addressbook_web_tests.tests
{
    [TestFixture]

    public class LoginTests : TestBase
    { 
        [Test]
         public void LoginWithValidCreds()
        {
            app.Auth.LogOut();

            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
         public void LoginWithInValidCreds()
        {
            app.Auth.LogOut();

            AccountData account = new AccountData("admin", "122345");
            app.Auth.Login(account);
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}

