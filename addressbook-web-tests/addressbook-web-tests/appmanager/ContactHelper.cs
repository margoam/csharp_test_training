using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase

    {
        public ContactHelper(ApplicationManager manager)
         : base(manager)
        {
        }

        public ContactHelper CreateContact(ContactData contact)
        {
            manager.Navigation.GoToContactCreationpage();
            FillContactForm(contact);
           SubmitContactCreation();
            return this;
        }
        public ContactHelper FillContactForm(ContactData contactdata)
        {
            Type(By.Name("firstname"), contactdata.Firstname);
            Type(By.Name("middlename"), contactdata.Middlename);
            Type(By.Name("lastname"), contactdata.Lastname);
            Type(By.Name("nickname"), contactdata.Nickname);
            Type(By.Name("company"), contactdata.Company);
            Type(By.Name("address"), contactdata.Address);
            Type(By.Name("home"), contactdata.Hometel);
            Type(By.Name("mobile"), contactdata.MobTel);
            Type(By.Name("work"), contactdata.WorkTel);

            return this;
        }
        internal ContactHelper Modify(int p, ContactData contact)
        {
            manager.Navigation.OpenHomePage();
            SelectContact(p);
            EditContact();
            FillContactForm(contact);
            SubmitContactUpdate();
            return this;
        }

        private ContactHelper SubmitContactUpdate()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[22]")).Click();
            contactCache = null;
            return this;
        }

        private ContactHelper EditContact()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            
            return this;
        }

        public ContactHelper SubmitContactCreation()
                {
                    driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;
            return this;
                }

        public ContactHelper Remove(int p)
        {
            manager.Navigation.OpenHomePage();
            SelectContact(p);
            RemoveContact();
            return this;
        }

        private ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(250);
            driver.FindElement(By.CssSelector("div.msgbox"));
            return this;
        }

        private ContactHelper SelectContact(int p)
        {
           
            Thread.Sleep(500);
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + p + "]")).Click();
            return this;
        }

        public bool CountContacts()
        {
           
            return (driver.FindElements(By.XPath("(//input[@name='selected[]'])"))).Count > 0;

        }


        public int GetCountContacts()
        {
            manager.Navigation.OpenHomePage();
            Thread.Sleep(500);
            return driver.FindElements(By.XPath("(//input[@name='selected[]'])")).Count;

        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigation.OpenHomePage();
                Thread.Sleep(500);
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
                foreach (IWebElement element in elements)
                {
                    var lastName = element.FindElement(By.XPath("td[2]")).Text;
                    var firstName = element.FindElement(By.XPath("td[3]")).Text;
                
                   
                    contactCache.Add(new ContactData(lastName, firstName)
                    {
                        Id = element.FindElement(By.Name("selected[]")).GetAttribute("value")
                    });
                }
            }
            return new List<ContactData>(contactCache);
        }
    }
}



