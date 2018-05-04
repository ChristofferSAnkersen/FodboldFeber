using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FodboldFeber.InstantSearch
{
    public class ResultItem //Group is Products in this example. Can be made to be anything by changing parameters through rest of code
    {
        public string Group { get; set; }

        public ResultItem(string group)
        {
            this.Group = group;
        }
    }
}
