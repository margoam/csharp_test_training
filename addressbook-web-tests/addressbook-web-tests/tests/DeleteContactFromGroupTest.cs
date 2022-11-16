using System;
using System.Linq;

namespace addressbook_web_tests
{
    public class DeleteContactFromGroupTests : AuthTestBase
    {
        [Test]

        public void TestDeletingContactFromGroup()

        {
            if (ContactData.GetAll().Count() == 0)
            {
                ContactData contactData = new ContactData(firstname: "First_name",
            lastname: "Last name");
                contactData.Middlename = "Middle_name";
                contactData.Nickname = "Nick name";
                contactData.Company = "Company name";
                contactData.Address = "Address test";
                app.Contacts.CreateContact(contactData);
            }


            if (GroupData.GetAll().Count() == 0)
            {

                GroupData groupData = new GroupData("name_edited");
                groupData.Header = "header_edited";
                groupData.Footer = null;
                app.Groups.CreateGroup(groupData);
            }

            List<ContactData> contacts = ContactData.GetAll();
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Concat(oldList).First();

            if(oldList.Count() == 0)
            {
                app.Contacts.AddContactToGroup(contacts[0], group);
            }

            app.Contacts.DeleteContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);

        }
    }
}

