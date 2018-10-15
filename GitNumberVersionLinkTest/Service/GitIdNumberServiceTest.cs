using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace GitNumberVersionLinkTest.Service
{
    [TestFixture]
    public class GitIdNumberServiceTest
    {
        [Test]
        public void GetNumberTest()
        {
            GitNumberVersionLink.Service.GitIdNumberService gitIdNumberService = new GitNumberVersionLink.Service.GitIdNumberService();
            List<string> errList = new List<string>();
            int number = gitIdNumberService.GetNumber("Project 1", "aaa", errList);
            Assert.Zero(errList.Count);
            Assert.AreEqual(1, number);

            number = gitIdNumberService.GetNumber("Project 1", "bbb", errList);
            Assert.Zero(errList.Count);
            Assert.AreEqual(2, number);

            number = gitIdNumberService.GetNumber("Project 1", "aaa", errList);
            Assert.Zero(errList.Count);
            Assert.AreEqual(1, number);

            number = gitIdNumberService.GetNumber("Project 2", "aaa", errList);
            Assert.Zero(errList.Count);
            Assert.AreEqual(1, number);
        }

        [SetUp]
        public void Setup()
        {
            GitNumberVersionLink.Settings.SqlConnection = Properties.Settings.Default.ConnectionString;
        }
    }
}
