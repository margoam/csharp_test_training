using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using addressbook_web_tests.tests;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture] // attribute
    public class TestBase
    {

        protected ApplicationManager app;


        [SetUp]
        public void Setuptest()
        {

            app = ApplicationManager.GetInstance();
        }


    }


}


