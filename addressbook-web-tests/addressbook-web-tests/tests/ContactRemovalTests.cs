using System;
namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            ContactData contact = new ContactData(firstname: "First_name", middlename: "Middle_name",
           lastname: "Last name", nickname: "Nick name", company: "Company name",
           address: "Address test", homeTel: "1231231231home", mobTel: "12312312mob",
           workTel: "12312312312work");

            app.Contacts.Remove(1, contact);

        }
    }
}

