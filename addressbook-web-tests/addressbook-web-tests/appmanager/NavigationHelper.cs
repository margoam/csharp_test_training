using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace addressbook_web_tests
{
    public class NavigationHelper : HelperBase
    {

    
        protected string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL)
       : base(manager)
        {
            this.baseURL = baseURL;
        }


        public void OpenHomePage()
        {
            if (driver.Url == baseURL + "/" && IsElementPresent(By.LinkText("add new")))
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
           
        }
        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/group.php" && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToContactCreationpage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}

