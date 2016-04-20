using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataLab.Models
{
    public class ReturnModel
    {
        public ReturnModel()
        {
            
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Category { get; set; }
        public dynamic ex;
    }
}
