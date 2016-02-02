using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeCompany
{
    public class Customer
    {
        public string lastName { get; set; }
        public string firstName { get; set; }
        public Gender gender { get; set; }
        public Address address { get; set; }
        public Product product { get; set; }
        public DateTime dateOfPurchase { get; set; }

        public Customer()
        {
            // Normally the initializer would be used to populate the class
            // from whatever data source being passed as a parameter.
            // In this simple example, the properties are filled in manually from the calling routine.
        }

    }


}
