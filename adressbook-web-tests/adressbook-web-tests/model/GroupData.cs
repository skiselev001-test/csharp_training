using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>
    {
        private string name;
        private string header = "";
        private string footer = "";

        public GroupData(string name)
        {
            this.name = name; 
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            { return false; }
            if (Object.ReferenceEquals(other, this))
            { return true; }
            return name == other.name; 
        }

        public int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public string Name 
        {
            set 
            { 
                this.name = value; 
            }
            get 
            {
                return this.name; 
            }
        }

        public string Header
        {
            get
            {
                return this.header;
            }
            set
            {
                this.header = value;
            }
        }

        public string Footer
        {
            get
            {
                return this.footer;
            }
            set
            {
                this.footer = value;
            }
        }
    }
}
