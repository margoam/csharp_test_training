﻿using System;
namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
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

            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData toBeRemoved = oldContacts[0];
            app.Contacts.Remove(toBeRemoved);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetCountContacts());

            oldContacts.Remove(toBeRemoved);
            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

        }
    }
}

