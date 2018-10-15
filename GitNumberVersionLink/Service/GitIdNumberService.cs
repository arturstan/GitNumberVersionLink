using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using GitNumberVersionLink.Model;

namespace GitNumberVersionLink.Service
{
    public class GitIdNumberService
    {
        public int GetNumber(string projectName, string commit, List<string> errList)
        {
            string sqlProject = "select * from Project where Name=@name";
            using (var connection = new SqlConnection(Settings.SqlConnection))
            {
                var project = connection.QueryFirstOrDefault<Project>(sqlProject, new { Name = projectName });
                if (project == null)
                {
                    errList.Add("");
                    return -1;
                }

                var gitNumber = Get(connection, project.Id, commit);
                if (gitNumber != null)
                {
                    return gitNumber.Number;
                }
                else
                {
                    Insert(connection, project.Id, commit);
                    gitNumber = Get(connection, project.Id, commit);
                    return gitNumber.Number;
                }
            }
        }

        private GitRepoNumber Get(SqlConnection connection, int idProject, string gitId)
        {
            string sqlGitRepo = "select * from GitIdNumber where IdProject=@IdProject and GitId=@GitId";
            return connection.QueryFirstOrDefault<GitRepoNumber>(sqlGitRepo, new { IdProject = idProject, GitId = gitId });
        }

        private void Insert(SqlConnection connection, int idProject, string gitId)
        {
            string sqlInsert = "insert into GitIdNumber (IdProject, GitId, Number) select @IdProject, @GitId, isnull(max(number),0) + 1 from GitIdNumber where IdProject=@IdProject";
            connection.Execute(sqlInsert, new { IdProject = idProject, GitId = gitId, });
        }
    }
}
