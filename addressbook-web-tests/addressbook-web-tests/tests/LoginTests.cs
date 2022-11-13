using System;
namespace addressbook_web_tests
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
            Assert.IsTrue(app.Auth.IsLoggIn(account));
        }

        [Test]
        public void LoginWithInValidCreds()
        {
            app.Auth.LogOut();
            Thread.Sleep(1000);

            AccountData account = new AccountData("admin", "122345");
            app.Auth.Login(account);
            Assert.IsFalse(app.Auth.IsLoggIn(account));
        }
    }
}