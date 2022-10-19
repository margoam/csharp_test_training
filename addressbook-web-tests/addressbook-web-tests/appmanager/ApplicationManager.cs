using System;
using System.Threading;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;// field
        protected LoginHelper loginHelper;
        protected NavigationHelper navigation;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";

            loginHelper = new LoginHelper(this);
            navigation = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);

        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
           
            }
        }


        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigation.OpenHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver? Driver
        {
            get
            {
                return driver;
            }
        }

        public LoginHelper Auth
        {
            get

            {
                return loginHelper;
            }

        }

        public NavigationHelper Navigation
        {
            get
            {
                return navigation;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }

        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }

    }
}

