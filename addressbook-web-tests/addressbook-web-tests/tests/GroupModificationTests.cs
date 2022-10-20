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
            GroupData groupNew = new GroupData("name_edited", "header_edited",
                null);
            GroupData group = new GroupData("name_created", "header_created",
                "footer_created");

            app.Groups.Modify(1, groupNew, group);
        }
    }
}

