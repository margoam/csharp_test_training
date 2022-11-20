﻿using System;
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
        public ContactHelper Modify(int p, ContactData contact)
        {
            manager.Navigation.OpenHomePage();
            SelectContact(p);
            EditContact(contact.Id);
            FillContactForm(contact);
            SubmitContactUpdate();
            return this;
        }

        internal ContactHelper Modify(ContactData selectContact, ContactData contact)
        {
            manager.Navigation.OpenHomePage();
            SelectContact(selectContact.Id);
            EditContact(selectContact.Id);
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

        private ContactHelper EditContact(String id)
        {
            driver.FindElement(By.CssSelector("a[href='edit.php?id="+ id +"']")).Click();

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

        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigation.OpenHomePage();
            SelectContact(contact.Id);
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

        private ContactHelper SelectContact(String id)
        {

            Thread.Sleep(500);
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value = '" + id + "'])")).Click();
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
                if (firstname != "")
                {
                    if (middlename == "" && lastname == "" && (nickname == "" && company == "" && address == "")
                        && (homePhone != "" || mobilePhone != "" || workPhone != "" || faxPhone != "" ||
                        (email != "" || email2 != "" || email3 != "")))
                    { firstname = firstname + "\r\n\r\n"; }
                    else if (middlename != "" || lastname != "")
                    { firstname = firstname + " "; }
                    else if (middlename == "" && lastname == "" && ((nickname != "" || company != "" || address != "")
                        || (homePhone != "" || mobilePhone != "" || workPhone != "" || faxPhone != "" ||
                        (email != "" || email2 != "" || email3 != ""))))
                    { firstname = firstname + "\r\n"; }
                }
                if (middlename != "")
                {
                    if (lastname == "" && (nickname == "" && company == "" && address == "") && (homePhone != "" || mobilePhone != "" || workPhone != "" || faxPhone != "" ||
                        (email != "" || email2 != "" || email3 != "")))
                    { middlename = middlename + "\r\n\r\n"; }
                    else if (lastname != "")
                    { middlename = middlename + " "; }
                    else if (lastname == "" && ((nickname != "" || company != "" || address != "")
                        || (homePhone != "" || mobilePhone != "" || workPhone != "" || faxPhone != "" ||
                        (email != "" || email2 != "" || email3 != ""))))
                    { middlename = middlename + "\r\n"; }
                }

                if (lastname != "")
                {
                    if (nickname == "" && company == "" && address == "" && (homePhone != "" || mobilePhone != "" || workPhone != "" || faxPhone != "" ||
                        (email != "" || email2 != "" || email3 != "")))
                    { lastname = lastname + "\r\n\r\n"; }
                    else if (nickname != "" || company != "" || address != "")
                    { lastname = lastname + "\r\n"; }
                }

                if (nickname != "")
                {
                    if (company != "" || address != "")
                    { nickname = nickname + "\r\n"; }
                    else if (company == "" && address == "" && (homePhone != "" || mobilePhone != "" || workPhone != "" || faxPhone != "" ||
                        (email != "" || email2 != "" || email3 != "")))
                    { nickname = nickname + "\r\n\r\n"; }
                }

                if (company != "")
                {
                    if (address == "" && (homePhone != "" || mobilePhone != "" || workPhone != "" || faxPhone != "" ||
                        (email != "" || email2 != "" || email3 != "")))
                    { company = company + "\r\n\r\n"; }
                    else if (address != "")
                    { company = company + "\r\n"; }
                }

                    if (address != "")
                {
                    if (homePhone != "" || mobilePhone != "" || workPhone != "" || faxPhone != "" ||
                        (email != "" || email2 != "" || email3 != ""))
                        { address = address + "\r\n\r\n"; }

                }

                if (homePhone != "")
                {
                    if (mobilePhone == "" && workPhone == "" && faxPhone == "" &&
                        (email != "" || email2 != "" || email3 != ""))
                    { homePhone = "H: " + homePhone + "\r\n\r\n"; }
                    else if (mobilePhone == "" && workPhone == "" && faxPhone == "" &&
                        (email == "" && email2 == "" && email3 == ""))
                    { homePhone = "H: " + homePhone; }
                    else
                    { homePhone = "H: " + homePhone + "\r\n"; }
                }

                if (mobilePhone != "")
                {
                    if (workPhone == "" && faxPhone == "" &&
                    (email != "" || email2 != "" || email3 != ""))
                    { mobilePhone = "M: " + mobilePhone + "\r\n\r\n"; }
                    else if (workPhone == "" && faxPhone == "" &&
                        (email == "" && email2 == "" && email3 == ""))
                    { mobilePhone = "M: " + mobilePhone; }
                    else
                    { mobilePhone = "M: " + mobilePhone + "\r\n"; }
                }

                if (workPhone != "")
                {
                    if (faxPhone == "" && (email != "" || email2 != "" || email3 != ""))
                    { workPhone = "W: " + workPhone + "\r\n\r\n"; }
                    else if (faxPhone == "" &&
                        (email == "" && email2 == "" && email3 == ""))
                    { workPhone = "W: " + workPhone; }
                    else
                    { workPhone = "W: " + workPhone + "\r\n"; }
                }

                if (faxPhone != "")
                {
                    if (email == "" && email2 == "" && email3 == "")
                    { faxPhone = "F: " + faxPhone; }
                    else if (email != "" || email2 != "" || email3 != "")
                    { faxPhone = "F: " + faxPhone + "\r\n\r\n"; }
                }

                if (email != "")
                {
                    if (email2 == "" && email3 == "")
                    { email = email + ""; }
                    else
                    {
                        email = email + "\r\n";
                    }
                }
                if (email2 != "")
                {
                    if (email3 == "")
                    { email2 = email2 + ""; }
                    else
                    { email2 = email2 + "\r\n"; }

                }
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

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigation.OpenHomePage();
            Thread.Sleep(200);
            ClearGroupFilter();
            SelectContactForGroup(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void DeleteContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigation.OpenHomePage();
            Thread.Sleep(200);
            SelectGroupForDeleteContact(group.Name);
            SelectContactForDelete(contact.Id);
            CommitDeletingContactFromGroup();

        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectContactForGroup(string id)
        {
            driver.FindElement(By.Id(id)).Click();
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public void SelectGroupForDeleteContact(string name)
        {
            Thread.Sleep(200);
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText($"{name}");
            Thread.Sleep(200);
        }

        public void SelectContactForDelete(string id)
        {
            driver.FindElement(By.Id(id)).Click();
        }

        public void CommitDeletingContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        

       
    }

    //select a contact not in a group

    //public object FindContactNotInGroup(List<ContactData> contacts, List<GroupData> groups)
    //{
    //    foreach (ContactData contact in contacts)
    //    {
    //        foreach (GroupData group in groups)
    //        {
    //            if (group.GetContacts().Contains(contact))
    //            {
    //                continue;
    //            }

    //            else if (!group.GetContacts().Contains(contact))
    //            {
    //                return Tuple.Create(contact, group);

    //            }
    //        }
    //    }
    //}

}
