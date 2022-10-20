using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager)
         : base(manager)

        {
        }

        public GroupHelper CreateGroup(GroupData group)
        {
            manager.Navigation.GoToGroupsPage();
            CreationNewGroup();
            FillGroupform(group);
               SubmitGroupCreation();
            return this;
        }


        public GroupHelper Modify(int p, GroupData newData, GroupData group)
        {
            manager.Navigation.GoToGroupsPage();
            if (!CountGroups())
            {
                CreateGroup(group);
                manager.Navigation.GoToGroupsPage();
            }
            SelectGroup(p);
            InitGroupModification();
            FillGroupform(newData);
            SubmitGroupModification();

            return this;
        }

       

        public GroupHelper CreationNewGroup()
                {
                    driver.FindElement(By.Name("new")).Click();
            return this;
                }
       

        public GroupHelper FillGroupform(GroupData groupdata)
        {
            Type(By.Name("group_name"), groupdata.Name);
            Type(By.Name("group_header"), groupdata.Header);
            Type(By.Name("group_footer"), groupdata.Footer);
            return this;
        }

       

        public GroupHelper Remove(int p, GroupData group)
        {
            manager.Navigation.GoToGroupsPage();
            if (!CountGroups())
            {
                CreateGroup(group);
                manager.Navigation.GoToGroupsPage();
            }
            SelectGroup(p);
            RemoveGroup(p);

            return this;
        }

        private GroupHelper RemoveGroup(int p)
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        private GroupHelper SelectGroup(int p)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + p + "]")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public bool CountGroups()
        {
            return (driver.FindElements(By.XPath("(//input[@name='selected[]'])"))).Count > 0;
            
        }
    }
}


