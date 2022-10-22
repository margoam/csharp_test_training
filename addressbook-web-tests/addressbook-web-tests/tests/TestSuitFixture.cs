using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{ 

    [SetUpFixture]
    public class TestSuitFixture
    {

        [OneTimeSetUp]

        public void SetupAppManager()
        {

            ApplicationManager app = ApplicationManager.GetInstance();
         

        }

        [OneTimeTearDown]
        public void StopAppManager()
        {
            ApplicationManager.GetInstance().Stop();


        }
    }
}

