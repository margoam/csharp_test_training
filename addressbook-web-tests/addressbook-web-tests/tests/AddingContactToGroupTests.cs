using System;
using System.Linq;

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

            List<GroupData> groups = GroupData.GetAll();
            ContactData? chosenContact = app.Contacts.FindContactNotInGroup();
            GroupData? group = null;

            //Selection a group and a contact for adding a contact to a group
            if (chosenContact == null)
            {
                ContactData contactData = new ContactData(firstname: "First_name",
            lastname: "Last name");
                contactData.Middlename = "Middle_name";
                contactData.Nickname = "Nick name";
                contactData.Company = "Company name";
                contactData.Address = "Address test";
                app.Contacts.CreateContact(contactData);
                Thread.Sleep(200);
                chosenContact = app.Contacts.FindContactNotInGroup();
                group = GroupData.GetAll()[0];
            }
            else
            {
                foreach (GroupData element in groups)
                {
                    if (!element.GetContacts().Contains(chosenContact))
                    {
                        group = element;
                        break;
                    }
                    else if (element.GetContacts().Contains(chosenContact))
                    {
                        continue;
                    }
                }
            }
           
            List<ContactData> oldList = group.GetContacts();

            app.Contacts.AddContactToGroup(chosenContact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(chosenContact);
            oldList.Sort();
            newList.Sort();

            Assert.That(newList, Is.EqualTo(oldList));

        }
    }
}

