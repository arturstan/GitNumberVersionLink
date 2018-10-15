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
    public class ProjectService
    {
        public void Add(Project proj, List<string> errList)
        {
            using (var connection = new SqlConnection(Settings.SqlConnection))
            {
                string sqlInsert = "insert into Project (Name) values (@Project)";
                connection.Execute(sqlInsert, new { Project = proj.Name });
            }
        }

        public Project Get(string name)
        {
            string sql = "select * from Project where name=@name";
            using (var connection = new SqlConnection(Settings.SqlConnection))
            {
                var project = connection.QueryFirstOrDefault<Project>(sql, new { Name = name });

                return project;
            }
        }
    }
}
