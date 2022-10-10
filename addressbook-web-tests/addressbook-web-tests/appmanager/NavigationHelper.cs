﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace addressbook_web_tests
{
    public class NavigationHelper : HelperBase
    {

    
        protected string baseURL;

        public NavigationHelper(IWebDriver driver, string baseURL)
       : base(driver)
        {
            this.baseURL = baseURL;
        }


        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
            Thread.Sleep(1000);
        }
        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToContactCreationpage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}

