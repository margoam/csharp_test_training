using System;
namespace addressbook_web_tests
{
    [TestFixture]

    public class ContactInformationTest : AuthTestBase
    {
        [Test]

        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromFrom = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromFrom);
            Assert.AreEqual(fromTable.Address, fromFrom.Address);
            Assert.AreEqual(fromTable.AllPhones, fromFrom.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromFrom.AllEmails);
        }


        [Test]
        public void TestContactViewInformation()
        {
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            ContactData fromViewForm = app.Contacts.GetContactInfoFromViewForm(0);

            Assert.AreEqual(fromForm.AllInformation, fromViewForm.AllInformation);
        }
    }
}
