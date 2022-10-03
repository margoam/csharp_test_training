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
    [TestFixture] // attribute
    public class GroupCreationTests
    {
        Initialization init = new Initialization();

        [Test]
        public void GroupCreationTest()
        {
            init.OpenHomePage();
            init.Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            CreationNewGroup();
            FillGroupform(new GroupData("name", "header", "footer"));
            SubmitGroupCreation();
            init.LogOut();

        }

        private void SubmitGroupCreation()
        {
            init.driver.FindElement(By.Name("submit")).Click();
        }

        private void FillGroupform(GroupData groupdata)
        {
            init.driver.FindElement(By.Name("group_name")).Click();
            init.driver.FindElement(By.Name("group_name")).Clear();
            init.driver.FindElement(By.Name("group_name")).SendKeys(groupdata.Name);
            init.driver.FindElement(By.Name("group_header")).Click();
            init.driver.FindElement(By.Name("group_header")).Clear();
            init.driver.FindElement(By.Name("group_header")).SendKeys(groupdata.Header);
            init.driver.FindElement(By.Name("group_footer")).Click();
            init.driver.FindElement(By.Name("group_footer")).Clear();
            init.driver.FindElement(By.Name("group_footer")).SendKeys(groupdata.Footer);
        }

        private void CreationNewGroup()
        {
            init.driver.FindElement(By.Name("new")).Click();
        }

        private void GoToGroupsPage()
        {
            init.driver.FindElement(By.LinkText("groups")).Click();
        }


        
    }
}
