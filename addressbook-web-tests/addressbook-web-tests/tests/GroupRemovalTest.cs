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

                GroupData group = new GroupData("name_edited");
                group.Header = "header_edited";
                group.Footer = null;
                app.Groups.CreateGroup(group);
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
      
            app.Groups.Remove(1);
            oldGroups.Remove(oldGroups[0]);
            List<GroupData> newGroups = app.Groups.GetGroupList();
         
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

