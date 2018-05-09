using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FodboldFeber.InstantSearch
{
    public class HelpResultItem : ResultItem 
        //If the help part in the bottom of the search is not wanted, 
        //this can be removed along with other pointers to HelpResultItem
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public HelpResultItem(string group, string title, string description)
            : base(group)
        {
            this.Title = title;
            this.Description = description;
        }
    }
}
