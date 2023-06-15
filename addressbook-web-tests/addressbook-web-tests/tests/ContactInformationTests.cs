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

            Assert.That(fromForm, Is.EqualTo(fromTable));
            Assert.That(fromForm.Address, Is.EqualTo(fromTable.Address));
            Assert.That(fromForm.AllPhones, Is.EqualTo(fromTable.AllPhones));
            Assert.That(fromForm.AllEmails, Is.EqualTo(fromTable.AllEmails));
        }


        [Test]
        public void TestContactViewInformation()
        {
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0, true);
            ContactData fromViewForm = app.Contacts.GetContactInfoFromViewForm(0);

            Assert.That(fromViewForm.AllInformation, Is.EqualTo(fromForm.AllInformation));
        }
    }
}
