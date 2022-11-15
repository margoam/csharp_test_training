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
            Thread.Sleep(250);
            manager.Navigation.GoToGroupsPage();
            CreationNewGroup();
            FillGroupform(group);
               SubmitGroupCreation();
            return this;
        }


        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigation.GoToGroupsPage();
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

       

        public GroupHelper Remove(int p)
        {
            manager.Navigation.GoToGroupsPage();
            SelectGroup(p);
            RemoveGroup();

            return this;
        }

        public GroupHelper Remove(GroupData group)
        {
            manager.Navigation.GoToGroupsPage();
            SelectGroup(group.Id);
            RemoveGroup();

            return this;
        }

        private GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        private GroupHelper SelectGroup(int p)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + p + "]")).Click();
            return this;
        }

        private GroupHelper SelectGroup(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value = '"+id+"'])")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public bool CountGroups()
        {
            manager.Navigation.GoToGroupsPage();
            return (driver.FindElements(By.XPath("(//input[@name='selected[]'])"))).Count > 0;
            
        }

        public int GetCountGroups()
        {
            manager.Navigation.GoToGroupsPage();
            Thread.Sleep(250);
            return driver.FindElements(By.XPath("(//input[@name='selected[]'])")).Count;

        }

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigation.GoToGroupsPage();
                Thread.Sleep(250);
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });

              
                }

            }
       
            return new List<GroupData>(groupCache);
        }

        
    }
}


