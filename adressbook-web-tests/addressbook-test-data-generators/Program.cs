using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using System.IO;

namespace addressbook_test_data_generators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter write = new StreamWriter(args[1]);

            for (int i = 0; i < count; i++)
            {
                write.WriteLine(String.Format("${0},${1},${2}",
                    TestBase.GenerateRandomString(10),
                    TestBase.GenerateRandomString(10),
                    TestBase.GenerateRandomString(10)));
            }
            write.Close();
        }
    }
}
