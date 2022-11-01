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
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(15), GenerateRandomString(15))
                {
                    Middlename = GenerateRandomString(15),
                    Nickname = GenerateRandomString(15),
                    Company = GenerateRandomString(10),
                    Address = GenerateRandomString(15)
                });
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
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


