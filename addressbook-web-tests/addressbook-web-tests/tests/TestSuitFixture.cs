using System;
namespace addressbook_web_tests.tests
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
            ApplicationManager.GetInstance().Quit();


        }
    }
}

