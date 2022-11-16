using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using LinqToDB.Mapping;

namespace addressbook_web_tests
{
    [Table(Name = "addressbook")]
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

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "firstname"), NotNull]
        public string Firstname { get; set; }

        [Column(Name = "middlename"), NotNull]
        public string Middlename { get; set; }

        [Column(Name = "lastname"), NotNull]
        public string Lastname { get; set; }

        [Column(Name = "nickname"), NotNull]
        public string Nickname { get; set; }

        [Column(Name = "company"), NotNull]
        public string Company { get; set; }

        [Column(Name = "address"), NotNull]
        public string Address { get; set; }

        [Column(Name = "home"), NotNull]
        public string Hometel { get; set; }

        [Column(Name = "fax"), NotNull]
        public string Fax { get; set; }

        [Column(Name = "mobile"), NotNull]
        public string MobTel { get; set; }

        [Column(Name = "work"), NotNull]
        public string WorkTel { get; set; }

        [Column(Name = "email"), NotNull]
        public string Email { get; set; }

        [Column(Name = "email2"), NotNull]
        public string Email2 { get; set; }

        [Column(Name = "email3"), NotNull]
        public string Email3 { get; set; }

        [Column(Name = "notes"), NotNull]
        public string Notes { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

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
                    return $"{(Lastname) + (Middlename) + (Firstname)}" +
                        $"{(Nickname)}{(Company)}{(Address)}" +
                        $"{(Hometel)  + (MobTel) + (WorkTel) + (Fax)}" +
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

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select g).ToList();
            }
        }

        public override int GetHashCode() => Tuple.Create(Firstname, Lastname).GetHashCode();
    }
}

