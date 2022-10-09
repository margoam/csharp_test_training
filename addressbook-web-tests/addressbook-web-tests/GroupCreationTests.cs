using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture] // attribute
    public class GroupCreationTests : Initialization
    {
        

        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            CreationNewGroup();
            FillGroupform(new GroupData("name", "header", "footer"));
            SubmitGroupCreation();
            LogOut();

        }
        
    }
}
