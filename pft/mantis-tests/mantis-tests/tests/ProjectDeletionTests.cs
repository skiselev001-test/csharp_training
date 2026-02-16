using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectDeletionTests : TestBase
    {
        [Test]

        public void TestProjectDeletion()
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

            app.Project.CreateProjectIfItNotExist(project, account);
            app.Project.Delete(project);

            Assert.IsFalse(app.Project.CheckAnExistingProject(project));


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
