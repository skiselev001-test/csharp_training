using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.DevTools.V141.CSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>,IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allNames;
        private string allFields;

        public ContactData(string firstname, string lastname) 
        { 
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            { return false; }
            if (Object.ReferenceEquals(other, this))
            { return true; }
            return (Firstname == other.Firstname) && (Lastname== other.Lastname);
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode(); 
        }

        public override string ToString()
        {
            return $"Firstname: {Firstname}, Lastname: {Lastname}";
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int resultOfCompare = Lastname.CompareTo(other.Lastname);
            
            if (resultOfCompare != 0) 
            { 
                return resultOfCompare;
            }

            return Firstname.CompareTo(other.Firstname);
        }

        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Home { get; set; }
        public string Password { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string HomePhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string Bday { get; set; }
        public string Bmonth { get; set; }
        public string Byear { get; set; }
        public string Aday { get; set; }
        public string Amonth { get; set; }
        public string Ayear { get; set; }
        public string Id { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                { return allPhones; }
                else
                {
                    return (CleanUpp(HomePhone) + CleanUpp(MobilePhone) + CleanUpp(WorkPhone)).Trim(); 
                }
            }
            set
            {
                allPhones = value;
            }
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                { return allEmails; }
                else
                { 
                    return (CleanUpp(Email) + CleanUpp(Email2) + CleanUpp(Email3)).Trim();
                }
            }
            set 
            {
                allEmails = value; 
            }
        }
        public string AllNames
        {
            get
            {
                if (allNames != null)
                { return allNames; }
                else
                {
                    return (CleanUpp(Firstname) + CleanUpp(Middlename) + CleanUpp(Lastname)).Trim();
                }
            }
            set
            {
                allNames = value;
            }
        }

        public string AllFields //except date
        {
            get
            {
                if (allFields != null)
                { return allFields; }
                else
                {
                    return (CleanUpp(Firstname + Middlename + Lastname) + CleanUpp(Nickname)
                        + CleanUpp(Title) + CleanUpp(Company) + CleanUpp(Address) 
                        + CleanUpp(HomePhone) + CleanUpp(MobilePhone) + CleanUpp(WorkPhone) 
                        + CleanUpp(Email) + CleanUpp(Email2) + CleanUpp(Email3) + CleanUpp(Homepage)).Trim();
                }
            }
            set
            {
                allNames = value;
            }
        }
        public string CleanUpp(string phone)
        {
            if (phone == null || phone =="")
            {
                return "";
            }
            // return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
            return Regex.Replace(phone, "[ ()HMW:-]", "") + "\r\n";
        }
    }
}
