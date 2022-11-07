using System;
using System.Reflection;
using System.Text.RegularExpressions;
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
            Type(By.Name("fax"), contactdata.Fax);
            Type(By.Name("mobile"), contactdata.MobTel);
            Type(By.Name("work"), contactdata.WorkTel);
            Type(By.Name("email"), contactdata.Email);
            Type(By.Name("email2"), contactdata.Email2);
            Type(By.Name("email3"), contactdata.Email3);

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

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigation.OpenHomePage();
            Thread.Sleep(250);
            IList<IWebElement> cells = driver.FindElements(By.XPath("//tr[@name='entry']"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;

            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };
        }

        public ContactData GetContactInformationFromEditForm(int index, bool ForViewPage = false)
        {
            manager.Navigation.OpenHomePage();
            InitContactModification(index);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string faxPhone = driver.FindElement(By.Name("fax")).GetAttribute("value");


            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            if (ForViewPage)
            {

                if (homePhone != "")
                { homePhone = "H: " + homePhone + "\n"; }
                if (mobilePhone != "")
                { mobilePhone = "M: " + mobilePhone + "\n"; }
                if (workPhone != "")
                { workPhone = "W: " + workPhone + "\n"; }
                if (faxPhone != "")
                { faxPhone = "F: " + faxPhone + "\n"; }

                if (email != "")
                { email = email + "\n"; }
                if (email2 != "")
                { email2 = email2 + "\n"; }

            }

            return new ContactData(firstname, lastname)
            {
                Middlename = middlename,
                Nickname = nickname,
                Address = address,
                Company = company,
                Hometel = homePhone,
                MobTel = mobilePhone,
                WorkTel = workPhone,
                Fax = faxPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        private void InitContactModification(int index)
        {
            Thread.Sleep(250);
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[7].FindElement(By.TagName("a")).Click();
        }

        public ContactHelper OpenViewForm(int index)
        {
            Thread.Sleep(250);
            driver.FindElements(By.XPath($"(//img[@title='Details'])"))[index].Click();
            return this;
        }

        public ContactData GetContactInfoFromViewForm(int index)
        {
            manager.Navigation.OpenHomePage();
            OpenViewForm(index);
            Thread.Sleep(100);
            string allInformation = (driver.FindElement(By.CssSelector("#content")).Text);
            return new ContactData
            {
                AllInformation = allInformation
            };
        }
    }
}



