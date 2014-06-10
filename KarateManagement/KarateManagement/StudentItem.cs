using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KarateManagement
{

    /// <summary>
    /// This class represents a Student Item to be used in the front end
    /// </summary>
    public class StudentItem : DependencyObject
    {
        public static readonly DependencyProperty IDProperty = DependencyProperty.Register(
            "ID", typeof(int), typeof(StudentItem), new PropertyMetadata(default(int)));

        public int ID
        {
            get { return (int)GetValue(IDProperty); }
            set { SetValue(IDProperty, value); }
        }

        public static readonly DependencyProperty FirstNameProperty = DependencyProperty.Register(
            "FirstName", typeof(string), typeof(StudentItem), new PropertyMetadata(default(string)));

        public string FirstName
        {
            get { return (string)GetValue(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }

        public static readonly DependencyProperty LastNameProperty = DependencyProperty.Register(
            "LastName", typeof(string), typeof(StudentItem), new PropertyMetadata(default(string)));

        public string LastName
        {
            get { return (string)GetValue(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }

        public static readonly DependencyProperty DateOfBirthProperty = DependencyProperty.Register(
            "DateOfBirth", typeof(DateTime), typeof(StudentItem), new PropertyMetadata(default(DateTime)));

        public DateTime DateOfBirth
        {
            get { return (DateTime)GetValue(DateOfBirthProperty); }
            set { SetValue(DateOfBirthProperty, value); }
        }

        public static readonly DependencyProperty AddressProperty = DependencyProperty.Register(
            "Address", typeof(string), typeof(StudentItem), new PropertyMetadata(default(string)));

        public string Address
        {
            get { return (string)GetValue(AddressProperty); }
            set { SetValue(AddressProperty, value); }
        }

        public static readonly DependencyProperty PostalCodeProperty = DependencyProperty.Register(
            "PostalCode", typeof(string), typeof(StudentItem), new PropertyMetadata(default(string)));

        public string PostalCode
        {
            get { return (string)GetValue(PostalCodeProperty); }
            set { SetValue(PostalCodeProperty, value); }
        }

        public static readonly DependencyProperty PhoneNumberProperty = DependencyProperty.Register(
            "PhoneNumber", typeof(string), typeof(StudentItem), new PropertyMetadata(default(string)));

        public string PhoneNumber
        {
            get { return (string)GetValue(PhoneNumberProperty); }
            set { SetValue(PhoneNumberProperty, value); }
        }

        public static readonly DependencyProperty EmailProperty = DependencyProperty.Register(
            "Email", typeof(string), typeof(StudentItem), new PropertyMetadata(default(string)));

        public string Email
        {
            get { return (string)GetValue(EmailProperty); }
            set { SetValue(EmailProperty, value); }
        }

        public static readonly DependencyProperty HoursProperty = DependencyProperty.Register(
            "Hours", typeof(int), typeof(StudentItem), new PropertyMetadata(default(int)));

        public int Hours
        {
            get { return (int)GetValue(HoursProperty); }
            set { SetValue(HoursProperty, value); }
        }

        public static readonly DependencyProperty BeltProperty = DependencyProperty.Register(
            "Belt", typeof(Belt), typeof(StudentItem), new PropertyMetadata(default(Belt)));

        public Belt Belt
        {
            get { return (Belt)GetValue(BeltProperty); }
            set { SetValue(BeltProperty, value); }
        }

        public static readonly DependencyProperty BalanceProperty = DependencyProperty.Register(
            "Balance", typeof(decimal), typeof(StudentItem), new PropertyMetadata(default(decimal)));

        public decimal Balance
        {
            get { return (decimal)GetValue(BalanceProperty); }
            set { SetValue(BalanceProperty, value); }
        }

        public static readonly DependencyProperty MembershipEndDateProperty = DependencyProperty.Register(
            "MembershipEndDate", typeof(DateTime), typeof(StudentItem), new PropertyMetadata(default(DateTime)));

        public DateTime MembershipEndDate
        {
            get { return (DateTime)GetValue(MembershipEndDateProperty); }
            set { SetValue(MembershipEndDateProperty, value); }
        }

        /// <summary>
        /// Function used to convert the StudentItem into an instance of the Student class
        /// </summary>
        /// <returns>A Student object</returns>
        public Student ToStudent()
        {
            return new Student(ID, FirstName, LastName, DateOfBirth, Address, PostalCode, PhoneNumber, Email, Hours, Belt, Balance, MembershipEndDate);
        }

        #region Constructor
        public StudentItem()
        {
            ID = SqlHelper.GetHighestID().Result;
            DateOfBirth = DateTime.Now;
            MembershipEndDate = DateTime.Now;
        }

        /// <summary>
        /// Parameterized constructor that copies the fiels of Student
        /// </summary>
        /// <param name="s">A student object to copy</param>
        public StudentItem(Student s)
        {
            ID = s.ID;
            FirstName = s.FirstName;
            LastName = s.LastName;
            DateOfBirth = s.DateOfBirth;
            Address = s.Address;
            PostalCode = s.PostalCode;
            PhoneNumber = s.PhoneNumber;
            Email = s.Email;
            Hours = s.Hours;
            Belt = s.Belt;
            Balance = s.Balance;
            MembershipEndDate = s.MembershipEndDate;
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="s">A student item to create a copy of</param>
        public StudentItem(StudentItem s)
        {
            ID = s.ID;
            FirstName = s.FirstName;
            LastName = s.LastName;
            DateOfBirth = s.DateOfBirth;
            Address = s.Address;
            PostalCode = s.PostalCode;
            PhoneNumber = s.PhoneNumber;
            Email = s.Email;
            Hours = s.Hours;
            Belt = s.Belt;
            Balance = s.Balance;
            MembershipEndDate = s.MembershipEndDate;
        }
        #endregion

        /// <summary>
        /// Copies the parameters of the student item
        /// </summary>
        /// <param name="s">A student item to copy its values</param>
        public void CopyFields(StudentItem s)
        {
            ID = s.ID;
            FirstName = s.FirstName;
            LastName = s.LastName;
            DateOfBirth = s.DateOfBirth;
            Address = s.Address;
            PostalCode = s.PostalCode;
            PhoneNumber = s.PhoneNumber;
            Email = s.Email;
            Hours = s.Hours;
            Belt = s.Belt;
            Balance = s.Balance;
            MembershipEndDate = s.MembershipEndDate;
        }


    }
}
