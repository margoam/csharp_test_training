using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
      
  
        public ContactData(string lastname, string firstname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public ContactData() { }

        private string allInformation;

        private string allPhones;

        private string allEmails;

        public string Id { get; set; }

        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string Nickname { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string Hometel { get; set; }

        public string Fax { get; set; }

        public string MobTel { get; set; }

        public string WorkTel { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Notes { get; set; }

        public string AllInformation
        {
            get
            {
                if (allInformation != null || allInformation == "")
                {
                    return allInformation;
                }
                else
                {
                    return $"{CleanUpForAllInformation((Lastname)+ " " + (Middlename) + " " + (Firstname))}" +
                        $"{CleanUpForAllInformation(Nickname)}{CleanUpForAllInformation(Company)}{CleanUpForAllInformation(Address) + "\n"}" +
                        $"{CleanUpForAllInformation((Hometel)  + (MobTel) + (WorkTel) + (Fax))}" +
                        $"{((Email)  + (Email2)  + (Email3))}";
                }
            }
            set => allInformation = value;
        }

public string AllPhones
        {
            get
            {
                if (allPhones != null || allPhones == "")
                {
                    return allPhones;
                }

                else
                {
                    return (CleanUp(Hometel) + CleanUp(MobTel) + CleanUp(WorkTel)).Trim();
                }
            }
            set => allPhones = value;
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null || allEmails == "")
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set => allEmails = value;
        }

        private string CleanUpForAllInformation(string value)
        {
            if (value == null || value == "")
            {
                return "";
            }
            else
            {
                return Regex.Replace(value, @"[\-]", "") + "\n";
            }
        }

        private string CleanUp(string value)
        {
            if (value == null || value == "")
            {
                return "";
            }
            else
            {
                return Regex.Replace(value, @"[ \-()\r]", "") + "\n";
            }
        }

        public int CompareTo(ContactData other)
        {
            if (ReferenceEquals(other, null))
                return 1;
                return String.Compare((Lastname + Firstname),
                other.Lastname + other.Firstname, StringComparison.Ordinal);
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

        public override int GetHashCode() => Tuple.Create(Firstname, Lastname).GetHashCode();
    }
}

