using System;
namespace addressbook_web_tests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {

        public GroupData(string name) // constructor
        {
            Name = name;
          
        }

        public GroupData()
        {

        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Header { get; set; }
        
        public string Footer { get; set; }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
         
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
                {
                return true;
            }
            return Name == other.Name;
         

        }

        public override string ToString()
        {
            return Name + " " + Header + " " + Footer ;
         
        }
    }
}

