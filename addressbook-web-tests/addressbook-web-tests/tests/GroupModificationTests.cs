using System;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace addressbook_web_tests.tests
{
    [TestFixture]

    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("name_edited", "header_edited",
                null);

            app.Groups.Modify(1, group);
        }
    }
}

