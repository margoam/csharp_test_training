using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
namespace addressbook_web_tests
{
    [TestFixture]

    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (!app.Groups.CountGroups())
            {
                GroupData group = new GroupData("name_edited", "header_edited",
                null);
                app.Groups.CreateGroup(group);
            }
            app.Groups.Remove(1);
        }
    }
}

