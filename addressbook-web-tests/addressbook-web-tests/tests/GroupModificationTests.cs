using System;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace addressbook_web_tests
{
    [TestFixture]

    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData groupNew = new GroupData("name_edited");
            groupNew.Header = "header";
            groupNew.Footer = "footer";
           

            if (!app.Groups.CountGroups())
            {
                GroupData group = new GroupData("name");
                group.Header = "header";
                group.Footer = "footer";
                app.Groups.CreateGroup(group);
            }
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData tobeModified = oldGroups[0];
            groupNew.Id = tobeModified.Id;
            oldGroups.Remove(tobeModified);
            app.Groups.Modify(tobeModified, groupNew);
            Thread.Sleep(500);
           
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(groupNew);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}