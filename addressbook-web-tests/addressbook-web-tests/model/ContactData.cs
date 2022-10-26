using System;
using System.Xml.Linq;

namespace addressbook_web_tests
{
    public class ContactData : IComparable<ContactData>
    {
        private string firstname;
        private string middlename = "";
        private string lastname;
        private string nickname = "";
        private string company = "";
        private string address = "";
        private string homeTel = "";
        private string mobTel = "";
        private string workTel = "";
  
        public ContactData(string lastname, string firstname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
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
        public int CompareTo(ContactData? other)
        {
            if (ReferenceEquals(other, null))
                return 1;
            return String.Compare((Lastname + Firstname), other.Lastname + other.Firstname, StringComparison.Ordinal);
        }

        public bool Equals(ContactData other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Lastname == other.Lastname && Firstname == other.Firstname;
           

        }

        public override string ToString()
        {
            return Lastname + " " + Firstname;
           
        }
        
    }
}

