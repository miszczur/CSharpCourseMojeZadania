using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourseMojeZadania
{
    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Contact(string name, string number)
        {
            Name = name;
            PhoneNumber = number;
        }


    }
}
