using System;
namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (!app.Contacts.CountContacts())
            {
                ContactData contact = new ContactData(firstname: "First_name",
            lastname: "Last name");
                contact.Middlename = "Middle_name";
                contact.Nickname = "Nick name";
                contact.Company = "Company name";
                contact.Address = "Address test";
                app.Contacts.CreateContact(contact);
            }

            ContactData contactnew = new ContactData(firstname: "First_name edit",
            lastname: "Last name edit");
            contactnew.Company = "Company name edit";
            contactnew.Address = "Address test edit";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(1, contactnew);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = contactnew.Firstname;
            oldContacts[0].Lastname = contactnew.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

