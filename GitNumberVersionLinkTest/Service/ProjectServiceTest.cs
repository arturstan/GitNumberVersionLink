using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace GitNumberVersionLinkTest.Service
{
    [TestFixture]
    public class ProjectServiceTest
    {
        [Test]
        public void AddProject()
        {
            List<string> errList = new List<string>();
            InsertProject("Project 1", errList);
            Assert.Zero(errList.Count);
            InsertProject("Project 2", errList);
            Assert.Zero(errList.Count);

            GitNumberVersionLink.Service.ProjectService projService = new GitNumberVersionLink.Service.ProjectService();
            GitNumberVersionLink.Model.Project proj = projService.Get("Project 1");
            Assert.NotNull(proj);
            GitNumberVersionLink.Model.Project proj2 = projService.Get("Project 2");
            Assert.NotNull(proj2);

        }

        [SetUp]
        public void Setup()
        {
            GitNumberVersionLink.Settings.SqlConnection = Properties.Settings.Default.ConnectionString;
        }

        private static void InsertProject(string name, List<string> errList)
        {
            GitNumberVersionLink.Model.Project proj = new GitNumberVersionLink.Model.Project { Name = name };
            GitNumberVersionLink.Service.ProjectService projService = new GitNumberVersionLink.Service.ProjectService();
            projService.Add(proj, errList);
        }
    }
}
