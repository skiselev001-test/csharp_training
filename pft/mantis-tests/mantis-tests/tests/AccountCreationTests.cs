using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [OneTimeSetUp]
        public void setUpConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open("C:\\Users\\Kiselev_S\\source\\repos\\skiselev001-test\\csharp_training\\pft\\mantis-tests\\mantis-tests\\tests\\config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            } 
            
        }

        [Test]
        public void TestAccountRegistration()
        {
            List<AccountData> accounts = new List<AccountData>();


            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };

            //   app.Admin.DeleteAccount(account);
            // app.Registration.CheckExistAccount(account);
            app.Registration.GenerateAccount(account);
            app.James.Delete(account);
            app.James.Add(account);

            app.Registration.Register(account);
        }

        [OneTimeTearDown]
        public void RestoreConfig() 
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }

        [OneTimeTearDown]
        public void Quit()
        {
            app.Driver.Quit();
        }
        

    }
}
