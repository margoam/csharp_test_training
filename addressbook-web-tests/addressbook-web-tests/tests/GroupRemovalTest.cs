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

            Assert.That(app.Groups.GetCountGroups(), Is.EqualTo(oldGroups.Count - 1));
            oldGroups.Remove(toBeRemoved);
            List<GroupData> newGroups = GroupData.GetAll();
         
            oldGroups.Sort();
            newGroups.Sort();
            Assert.That(newGroups, Is.EqualTo(oldGroups));

            foreach (GroupData group in newGroups)
            {
                Assert.That(toBeRemoved.Id, Is.Not.EqualTo(group.Id));
            }
        }
    }
}

