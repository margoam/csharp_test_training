using System;
namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
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

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeModified = oldContacts[0];
            contactEditData.Id = toBeModified.Id;
            oldContacts.Remove(toBeModified);
            app.Contacts.Modify(toBeModified, contactEditData);
      
            Thread.Sleep(200);
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Add(contactEditData);

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

           
        }
    }
}

