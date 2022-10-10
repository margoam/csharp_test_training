using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationtest : Initialization
    {

        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToContactCreationpage();
            FillContactForm(new ContactData(firstname:"First_name", middlename:"Middle_name",
            lastname:"Last name",nickname:"Nick name", company: "Company name",
            address: "Address test", homeTel: "1231231231home", mobTel:"12312312mob",
            workTel: "12312312312work"));
            SubmitContactCreation();
            LogOut();
        }


    }

}


