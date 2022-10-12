﻿using System;
namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData(firstname: "First_name2", middlename: "Middle_name2",
            lastname: "Last name2", nickname: "Nick name2", company: "Company name2",
            address: "Address test2", homeTel: "1231231231home2", mobTel: "12312312mob2",
            workTel: "12312312312work2");


            app.Contacts.Modify(1, contact);
        }
    }
}

