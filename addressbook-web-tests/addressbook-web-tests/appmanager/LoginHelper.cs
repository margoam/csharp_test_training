using System;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class LoginHelper : HelperBase
    { 
            public LoginHelper(ApplicationManager manager)
        : base(manager)

            {
            }

            public void Login(AccountData account)
            {
                if (IsLoggIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                LogOut();
            }
            Thread.Sleep(1000);
            Type(By.Name("user"), account.Username);
                
                driver.FindElement(By.XPath("//*/text()[normalize-space(.)='']/parent::*")).Click();
                Type(By.Name("pass"), account.Password);
                driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggIn()
            && driver.FindElement(By.XPath("//div[@id='top']/form/b")).Text
            == "(" + account.Username + ")";
        }

        public bool IsLoggIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public void LogOut()
        {
            if (IsLoggIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }
        
    }
}

