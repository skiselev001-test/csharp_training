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
            AccauntData account = new AccauntData()
            {
                Name = "Administrator",
                Password = "root",
                //Email = "testuser@localhost.localdomain"
            };

            ProjectData project = new ProjectData()
            {
                Name = "TestProject_1"
            };

            app.Project.Create(project, account);

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
