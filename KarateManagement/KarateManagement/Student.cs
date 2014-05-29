using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateManagement
{
    /// <summary>
    /// This class will be a representation of a student
    /// </summary>
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int Hours { get; set; }

        public Belt Belt { get; set; }

        public Student()
        {

        }

        public override string ToString()
        {
            String s = "{0} {1} {2} {3} {4} {5} {6} {7} {8}";
            String s2 = String.Format(s, FirstName, LastName, DateOfBirth, Address, PostalCode, PhoneNumber,
                Email, Hours, Belt);
            return s2;
        }

    }
}
