using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FodboldFeber.InstantSearch
{
    public class ErrorResultItem : ResultItem
        //This basically just shows an error, as so far an error occurs. 
        //Shouldnt happen, if everything else works :)
    {
        public string ErrorMessage { get; set; }

        public ErrorResultItem(string group, string errorMessage)
            : base(group)
        {
            this.ErrorMessage = errorMessage;
        }
    }
}
