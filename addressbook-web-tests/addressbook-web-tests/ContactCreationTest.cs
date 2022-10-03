using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationtest
    {
        Initialization init = new Initialization();

        [Test]
        public void ContactCreationTest()
        {
            init.OpenHomePage();
            init.Login(new AccountData("admin", "secret"));
            GoToContactCreationpage();
            FillContactForm(new ContactData("First_name", "Last_name", "Company", "Address", "1123123"));
            SubmitContactCreation();
            init.LogOut();
        }

        private void SubmitContactCreation()
        {
            init.driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
        }

        private void FillContactForm(ContactData contactdata)
        {
            init.driver.FindElement(By.Name("firstname")).Click();
            init.driver.FindElement(By.Name("firstname")).Clear();
            init.driver.FindElement(By.Name("firstname")).SendKeys(contactdata.Firstname);
            init.driver.FindElement(By.Name("middlename")).Click();
            init.driver.FindElement(By.Name("middlename")).Clear();
            init.driver.FindElement(By.Name("middlename")).SendKeys(contactdata.Middlename);
            init.driver.FindElement(By.Name("lastname")).Click();
            init.driver.FindElement(By.Name("lastname")).Clear();
            init.driver.FindElement(By.Name("lastname")).SendKeys(contactdata.Lastname);
            init.driver.FindElement(By.Name("nickname")).Click();
            init.driver.FindElement(By.Name("nickname")).Clear();
            init.driver.FindElement(By.Name("nickname")).SendKeys(contactdata.Nickname);
            init.driver.FindElement(By.Name("company")).Click();
            init.driver.FindElement(By.Name("company")).Clear();
            init.driver.FindElement(By.Name("company")).SendKeys(contactdata.Company);
            init.driver.FindElement(By.Name("address")).Click();
            init.driver.FindElement(By.Name("address")).Clear();
            init.driver.FindElement(By.Name("address")).SendKeys(contactdata.Address);
            init.driver.FindElement(By.Name("home")).Click();
            init.driver.FindElement(By.Name("home")).Clear();
            init.driver.FindElement(By.Name("home")).SendKeys(contactdata.Hometel);
            init.driver.FindElement(By.Name("mobile")).Click();
            init.driver.FindElement(By.Name("mobile")).Clear();
            init.driver.FindElement(By.Name("mobile")).SendKeys(contactdata.MobTel);
            init.driver.FindElement(By.Name("work")).Click();
            init.driver.FindElement(By.Name("work")).Clear();
            init.driver.FindElement(By.Name("work")).SendKeys(contactdata.WorkTel);
        }

        private void GoToContactCreationpage()
        {
            init.driver.FindElement(By.LinkText("add new")).Click();
        }

    }

}


