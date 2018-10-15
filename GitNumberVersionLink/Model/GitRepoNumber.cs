using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitNumberVersionLink.Model
{
    public class GitRepoNumber
    {
        public int IdProject { get; set; }
        public string GitCommit { get; set; }
        public int Number { get; set; }
    }
}
