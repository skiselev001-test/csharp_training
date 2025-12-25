using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData
    {
        private string name;
        private string header = "";
        private string footer = "";

        public GroupData(string name)
        {
            this.name = name; 
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
