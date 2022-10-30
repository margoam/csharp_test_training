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

            ContactData contactEditData = new ContactData(firstname: "First_name edit",
            lastname: "Last name edit");
            contactEditData.Company = "Company name edit";
            contactEditData.Address = "Address test edit";

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(1, contactEditData);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Lastname = contactEditData.Lastname;
            oldContacts[0].Firstname = contactEditData.Firstname;
            
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(contactEditData.Firstname, oldData.Firstname);
                    Assert.AreEqual(contactEditData.Lastname, oldData.Lastname);
                }
            }
        }
    }
}

