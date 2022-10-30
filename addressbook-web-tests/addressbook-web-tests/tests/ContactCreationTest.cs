using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationtest : AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData(firstname: "First_name", lastname: "Last name");
            contact.Middlename = "Middle_name";
            contact.Nickname = "Nick name";
            contact.Company = "Company name";
            contact.Address = "Address test"; 
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.CreateContact(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetCountContacts());
         
            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }


    }

}


