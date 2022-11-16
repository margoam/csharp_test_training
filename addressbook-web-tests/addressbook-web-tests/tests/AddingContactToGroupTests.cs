using System;
namespace addressbook_web_tests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]

        public void TestAddingContactToGroup()

        {
            if (ContactData.GetAll().Count() == 0 )
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


            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);

        }
    }
}

