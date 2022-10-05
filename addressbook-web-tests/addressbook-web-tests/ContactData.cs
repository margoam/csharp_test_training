using System;
using System.Xml.Linq;

namespace addressbook_web_tests
{
    public class ContactData
    {

        private string firstname;
        private string middlename;
        private string lastname;
        private string nickname;
        private string company;
        private string address;
        private string homeTel;
        private string mobTel;
        private string workTel;
  
        public ContactData(string firstname, string middlename, string lastname,
            string nickname, string company, string address, string homeTel,
            string mobTel, string workTel)
        {
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;
            this.nickname = nickname;
            this.company = company;
            this.address = address;
            this.homeTel = homeTel;
            this.mobTel = mobTel;
            this.workTel = workTel;
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string Hometel
        {
            get
            {
                return homeTel;
            }
            set
            {
                homeTel = value;
            }
        }

        public string MobTel
        {
            get
            {
                return mobTel;
            }
            set
            {
                mobTel = value;
            }
        }

        public string WorkTel
        {
            get
            {
                return workTel;
            }
            set
            {
                workTel = value;
            }
        }
    }
}

