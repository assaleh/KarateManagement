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
        public int ID { get; set; } 
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int Hours { get; set; }

        public Belt Belt { get; set; }

        public decimal Balance { get; set; }

        public DateTime MembershipEndDate { get; set; }

        public Student()
        {
        }

        public Student(int id, string firstName, string lastName, DateTime dateOfBirth, string address, string postalCode, 
            string phoneNumber, string email, int hours, Belt belt, decimal balance, DateTime membershipEndDate)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Address = address;
            PostalCode = postalCode;
            PhoneNumber = phoneNumber;
            Email = email;
            Hours = hours;
            Belt = belt;
            Balance = balance;
            MembershipEndDate = membershipEndDate;
        }

        public override string ToString()
        {
            String s = "{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}";
            String s2 = String.Format(s,ID, FirstName, LastName, DateOfBirth, Address, PostalCode, PhoneNumber,
                Email, Hours, Belt);
            return s2;
        }

    }
}
