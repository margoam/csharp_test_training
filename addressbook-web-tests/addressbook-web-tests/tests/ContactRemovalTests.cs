using System;
namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.Remove(1);

        }
    }
}

