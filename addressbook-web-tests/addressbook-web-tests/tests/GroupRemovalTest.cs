using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
namespace addressbook_web_tests
{
    [TestFixture]

    public class GroupRemovalTests : GroupTestBase
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
            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData toBeRemoved = oldGroups[0];

            app.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetCountGroups());
            oldGroups.Remove(oldGroups[0]);
            List<GroupData> newGroups = GroupData.GetAll();
         
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}

