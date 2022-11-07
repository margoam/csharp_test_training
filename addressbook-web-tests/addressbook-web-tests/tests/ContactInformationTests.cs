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
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }


        [Test]
        public void TestContactViewInformation()
        {
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0, true);
            ContactData fromViewForm = app.Contacts.GetContactInfoFromViewForm(0);

            Assert.AreEqual(fromForm.AllInformation, fromViewForm.AllInformation);
        }
    }
}
