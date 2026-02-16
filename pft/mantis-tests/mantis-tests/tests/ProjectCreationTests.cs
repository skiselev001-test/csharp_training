using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [Test]

        public void TestProjectRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "Administrator",
                Password = "root",
                //Email = "testuser@localhost.localdomain"
            };

            ProjectData project = new ProjectData()
            {
                Name = "TestProject_1"
            };

            app.Project.DeleteProjectIfItExist(project, account);
            app.Project.Create(project);

            Assert.IsTrue(app.Project.CheckAnExistingProject(project));
            
            
        }


        /*
        [OneTimeTearDown]
        public void RestoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }
        */

        [OneTimeTearDown]
        public void Quit()
        {
            app.Driver.Quit();
        }
    }
}
