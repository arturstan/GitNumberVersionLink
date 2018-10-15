using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitNumberVersionLinkConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() != 2)
            {
                Console.Out.WriteLine("args count != 2");
                return;
            }

            string project = args[0];
            string gitId = args[1];

            GitNumberVersionLink.Settings.SqlConnection = Properties.Settings.Default.ConnectionString;

            List<string> errList = new List<string>();
            GitNumberVersionLink.Service.GitIdNumberService gitNumberService = new GitNumberVersionLink.Service.GitIdNumberService();
            int number = gitNumberService.GetNumber(project, gitId, errList);
            if (errList.Count > 0)
                Console.Out.WriteLine(errList);
            else
                Console.Out.WriteLine(number);
        }
    }
}
