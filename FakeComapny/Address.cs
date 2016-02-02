using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeCompany
{
    public class Address
    {
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipCode { get; set; }    // for simplicity, use 5-digit zip

        public Address(string _address, string _city, string _state, int _zipCode)
        {
            address = _address;
            city = _city;
            state = _state;
            zipCode = _zipCode;
        }

        // example of how to specify the string representation of Address
        public override string ToString()
        {
            return string.Format("{0}\n{1}, {2}  {3}", address, city, state, zipCode);
        }



    }
}
