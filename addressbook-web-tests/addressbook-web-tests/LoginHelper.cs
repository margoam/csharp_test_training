using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class LoginHelper : HelperBase
    { 
            public LoginHelper(IWebDriver driver)
        : base(driver)

            {
            }

            public void Login(AccountData account)
            {
                driver.FindElement(By.Name("user")).Click();
                driver.FindElement(By.Name("user")).Clear();
                driver.FindElement(By.Name("user")).SendKeys(account.Username);
                driver.FindElement(By.XPath("//*/text()[normalize-space(.)='']/parent::*")).Click();
                driver.FindElement(By.Name("pass")).Click();
                driver.FindElement(By.Name("pass")).Clear();
                driver.FindElement(By.Name("pass")).SendKeys(account.Password);
                driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            }

            public void LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        
    }
}

