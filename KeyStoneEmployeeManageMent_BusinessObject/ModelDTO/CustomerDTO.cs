using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyStoneEmployeeManageMent_BusinessObject.ModelDTO
{
    public class CustomerDTO
    {
        public int id { get; set; }
        public string Customername { get; set; }
        public string Email { get; set; }
        public string country { get; set; }
        public string city { get; set; }
    }
}
