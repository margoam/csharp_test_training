using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture] // attribute
    public class GroupCreationTests : TestBase
    {
        

        [Test]
        public void GroupCreationTest()
        {
            app.Navigation.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigation.GoToGroupsPage();
            app.Groups.CreationNewGroup();
            app.Groups.FillGroupform(new GroupData("name", "header", "footer"));
            app.Groups.SubmitGroupCreation();
            app.Auth.LogOut();

        }
        
    }
}
