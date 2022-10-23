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
                ContactData contact = new ContactData(firstname: "First_name", middlename: "Middle_name",
          lastname: "Last name", nickname: "Nick name", company: "Company name",
          address: "Address test", homeTel: "1231231231home", mobTel: "12312312mob",
          workTel: "12312312312work");
                app.Contacts.CreateContact(contact);
            }

            ContactData contactnew = new ContactData(firstname: "First_name2", middlename: "Middle_name2",
            lastname: "Last name2", nickname: "Nick name2", company: "Company name2",
            address: "Address test2", homeTel: "1231231231home2", mobTel: "12312312mob2",
            workTel: "12312312312work2");


            app.Contacts.Modify(1, contactnew);
        }
    }
}

