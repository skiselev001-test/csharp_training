using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace addressbook_test_data_generators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);

            string type = args[3];
            string format = args[2];
            string filename = args[1];

            List<GroupData> groups = new List<GroupData>();
            List<ContactData> contacts = new List<ContactData>();

           

            //       if (format == "excel")
            //       {
            //           writeGroupsToExcelFile(groups, filename);
            //       }
            //       else
            //       {
            StreamWriter writer = new StreamWriter(filename);

            if (type == "groups")
            {
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }

                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    writeGroupToJsonFile(groups, writer);
                }
                
            }
            else if (type == "contacts")
            {
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                    {
                        Middlename = TestBase.GenerateRandomString(10),
                        Nickname = TestBase.GenerateRandomString(10),
                        Title = TestBase.GenerateRandomString(10),
                        Company = TestBase.GenerateRandomString(10),
                        Address = TestBase.GenerateRandomString(10),
                        HomePhone = TestBase.GenerateRandomString(10),
                        MobilePhone = TestBase.GenerateRandomString(10),
                        WorkPhone = TestBase.GenerateRandomString(10),
                        Email = TestBase.GenerateRandomString(10),
                        Email2 = TestBase.GenerateRandomString(10),
                        Email3 = TestBase.GenerateRandomString(10),
                        Homepage = TestBase.GenerateRandomString(10)
                    });
                }

                if (format == "csv")
                {
                    writeContactsToCsvFile(contacts, writer);
                }
                else if (format == "xml")
                {
                    writeContactsToXmlFile(contacts, writer);
                }
                else if (format == "json")
                {
                    writeContactsToJsonFile(contacts, writer);
                }
            }
            else
            {
                System.Console.Out.Write("Unrecognized type: " + type);
            }

            if (format != "csv" && format != "json" && format != "xml")
            {
                System.Console.Out.Write("Unrecognized format: " + format);
            }

            writer.Close();
              //       }

        }

        static void writeGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs2(Path.Combine(Directory.GetCurrentDirectory(), filename));
            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter write)
        {
            foreach (GroupData group in groups)
            {
                write.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupToJsonFile(List<GroupData> groups, StreamWriter write)
        {
            write.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
            //write.Write(JsonConvert.SerializeObject(groups));
        }

        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter write)
        {
            foreach (ContactData contact in contacts)
            {
                write.WriteLine(String.Format("${0},${1},${2},${3},${4},${5},${6},${7},${8},${9},${10},${11},${12},${13}",
                    contact.Firstname, contact.Lastname, contact.Middlename,contact.Nickname, contact.Title,
                    contact.Company, contact.Address, contact.HomePhone, contact.MobilePhone, contact.WorkPhone, 
                    contact.Email, contact.Email2, contact.Email3, contact.Homepage));
            }
        }

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter write)
        {
            write.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
