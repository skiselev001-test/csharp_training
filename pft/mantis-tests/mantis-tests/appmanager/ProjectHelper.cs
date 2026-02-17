using mantis_tests.Mantis;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper (ApplicationManager manage) : base (manage) { }


        public void OpenProjectTab()
        {
            driver.FindElement(By.XPath("//a[text()='Projects']")).Click();
        }

        public void Create(ProjectData project)
        {
         /* manager.Registration.OpenMainPage();
            manager.Registration.Login(account);
            OpenProjectTab();
            if (CheckAnExistingProject(project))
            {
                SelectProjectToDelete(project);
                SubmitDeletionProject();
            }
         */
            if (! CheckAnExistingProject(project))
            {
                OpenNewProjectForm();
                FillCreateProjectForm(project);
                SubmitCreationNewProject();
            }
        }

        public void DeleteProjectIfItExist(ProjectData project, AccountData account)
        {
            manager.Registration.OpenMainPage();
            manager.Registration.Login(account);
            OpenProjectTab();
            if (CheckAnExistingProject_API(project, account))
            {
                SelectProjectToDelete(project);
                SubmitDeletionProject();
            }
        }

        public void Delete(ProjectData project)
        {
         /* manager.Registration.OpenMainPage();
            manager.Registration.Login(account);
            OpenProjectTab();
            if (!CheckAnExistingProject(project))
            {
                OpenNewProjectForm();
                FillCreateProjectForm(project);
                SubmitCreationNewProject();
            }
         */
            if (CheckAnExistingProject(project))
            {
                SelectProjectToDelete(project);
                SubmitDeletionProject();
            }

        }

        public void Delete_Hybrid(ProjectData project, AccountData account)
        {
               manager.Registration.OpenMainPage();
               manager.Registration.Login(account);
               OpenProjectTab();
           /*    if (!CheckAnExistingProject(project))
               {
                   OpenNewProjectForm();
                   FillCreateProjectForm(project);
                   SubmitCreationNewProject();
               }
            */
            if (CheckAnExistingProject_API(project, account))
            {
                SelectProjectToDelete(project);
                SubmitDeletionProject();
            }

        }

        public void CreateProjectIfItNotExist(ProjectData project, AccountData account)
        {
            manager.Registration.OpenMainPage();
            manager.Registration.Login(account);
            OpenProjectTab();
            if (!CheckAnExistingProject(project))
            {
                OpenNewProjectForm();
                FillCreateProjectForm(project);
                SubmitCreationNewProject();
            }
        }

        private void SubmitDeletionProject()
        {
            driver.FindElement(By.XPath("//button[contains(text(),'Delete')]")).Click();
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
        }

        private void SelectProjectToDelete(ProjectData project)
        {
            ICollection<IWebElement> elements = driver.FindElements(By
                .XPath("//div[@class='col-md-12 col-xs-12']/div[@class='widget-box widget-color-blue2']//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr/td[1]"));
            int index = 1;
            foreach (IWebElement element in elements)
            {
                if (project.Name == element.Text)
                {
                    driver.FindElement(By
                .XPath("//div[@class='col-md-12 col-xs-12']/div[@class='widget-box widget-color-blue2']//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr["+index.ToString()+"]/td[1]/a")).Click();
                    return;
                }
                index++;
            }
        }

        private void SubmitCreationNewProject()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void FillCreateProjectForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
//driver.FindElement(By.Name("description")).SendKeys(project.Description);
        }

        private void OpenNewProjectForm()
        {
            driver.FindElement(By.CssSelector("div.col-md-12>div.widget-box button.btn")).Click();
        }

        public bool CheckAnExistingProject(ProjectData project)
        {
            List<ProjectData> projectList = new List<ProjectData>();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("div.col-md-12>div.widget-box table.table-striped>tbody>tr"));
            foreach (IWebElement element in elements)
            {
                projectList.Add(new ProjectData() { Name = element.FindElement(By.CssSelector("td:nth-child(1)")).Text });
            } 
            foreach (ProjectData projectData in projectList)
            {
                if (projectData.Name == project.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckAnExistingProject_API(ProjectData project, AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();

            Mantis.ProjectData[] projects; 

            projects = client.mc_projects_get_user_accessible(account.Name, account.Password);

            if (projects.Length > 0)
            {
                for (int i = 0; i < projects.Length; i++)
                {
                    if (projects[i].name == project.Name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void CreateProjectIfItNotExist_API(ProjectData project, AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projectAPI = new Mantis.ProjectData();

            if (!CheckAnExistingProject_API(project, account))
            {
                projectAPI.name = project.Name;
                client.mc_project_add(account.Name, account.Password, projectAPI);
            }
        }

    }
}
