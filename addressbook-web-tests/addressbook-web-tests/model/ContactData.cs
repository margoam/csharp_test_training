using System;
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

        public string Id { get; set; }

        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string Nickname { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string Hometel { get; set; }

        public string MobTel { get; set; }

        public string WorkTel { get; set; }

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

