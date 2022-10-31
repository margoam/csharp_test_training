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
                if (IsLoggIn(account))
                {
                    return;
                }
                LogOut();
            }
            Thread.Sleep(500);
            Type(By.Name("user"), account.Username);
                
                driver.FindElement(By.XPath("//*/text()[normalize-space(.)='']/parent::*")).Click();
                Type(By.Name("pass"), account.Password);
                driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            }

        public bool IsLoggIn(AccountData account)
        {
            return IsLoggIn()
            && GetLoggedUserName() == account.Username;
        }

        public string GetLoggedUserName()
        {
            string text = driver.FindElement(By.XPath("//div[@id='top']/form/b")).Text;
            return text.Substring(1, text.Length - 2);
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

