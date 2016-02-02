using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeCompany
{
    public class Company
    {
        public string name { get; set; }
        public Address address { get; set; }
        public Product product { get; set; }
        public string motivationalTool { get; set; }

        public Company(string _name, Address _address, Product _product, string tool)
        {

            name = _name;
            address = _address;
            product = _product;
            motivationalTool = tool;
        }
    }

    

    

}
