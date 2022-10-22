using System;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
namespace addressbook_web_tests
{

    public class AuthTestBase : TestBase 
    {
        [SetUp]
        public void SetupLogin()
        {

            app.Auth.Login(new AccountData("admin", "secret"));

        }

    }
}

