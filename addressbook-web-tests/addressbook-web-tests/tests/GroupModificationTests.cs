using System;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace addressbook_web_tests
{
    [TestFixture]

    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData groupNew = new GroupData("name_edited");
            groupNew.Header = "header";
            groupNew.Footer = "footer";
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (!app.Groups.CountGroups())
            {
                GroupData group = new GroupData("name");
                group.Header = "header";
                group.Footer = "footer";
                app.Groups.CreateGroup(group);
            }

            app.Groups.Modify(1, groupNew);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = groupNew.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}