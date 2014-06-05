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
        public static readonly DependencyProperty IdProperty = DependencyProperty.Register(
            "Id", typeof (int), typeof (StudentItem), new PropertyMetadata(default(int)));

        public int Id
        {
            get { return (int) GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        public static readonly DependencyProperty FirstNameProperty = DependencyProperty.Register(
            "FirstName", typeof (string), typeof (StudentItem), new PropertyMetadata(default(string)));

        public string FirstName
        {
            get { return (string) GetValue(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }

        public static readonly DependencyProperty LastNameProperty = DependencyProperty.Register(
            "LastName", typeof (string), typeof (StudentItem), new PropertyMetadata(default(string)));

        public string LastName
        {
            get { return (string) GetValue(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }

        public static readonly DependencyProperty DateOfBirthProperty = DependencyProperty.Register(
            "DateOfBirth", typeof (DateTime), typeof (StudentItem), new PropertyMetadata(default(DateTime)));

        public DateTime DateOfBirth
        {
            get { return (DateTime) GetValue(DateOfBirthProperty); }
            set { SetValue(DateOfBirthProperty, value); }
        }

        public static readonly DependencyProperty AddressProperty = DependencyProperty.Register(
            "Address", typeof (string), typeof (StudentItem), new PropertyMetadata(default(string)));

        public string Address
        {
            get { return (string) GetValue(AddressProperty); }
            set { SetValue(AddressProperty, value); }
        }

        public static readonly DependencyProperty PostalCodeProperty = DependencyProperty.Register(
            "PostalCode", typeof (string), typeof (StudentItem), new PropertyMetadata(default(string)));

        public string PostalCode
        {
            get { return (string) GetValue(PostalCodeProperty); }
            set { SetValue(PostalCodeProperty, value); }
        }

        public static readonly DependencyProperty PhoneNumberProperty = DependencyProperty.Register(
            "PhoneNumber", typeof (string), typeof (StudentItem), new PropertyMetadata(default(string)));

        public string PhoneNumber
        {
            get { return (string) GetValue(PhoneNumberProperty); }
            set { SetValue(PhoneNumberProperty, value); }
        }

        public static readonly DependencyProperty EmailProperty = DependencyProperty.Register(
            "Email", typeof (string), typeof (StudentItem), new PropertyMetadata(default(string)));

        public string Email
        {
            get { return (string) GetValue(EmailProperty); }
            set { SetValue(EmailProperty, value); }
        }

        public static readonly DependencyProperty HoursProperty = DependencyProperty.Register(
            "Hours", typeof (int), typeof (StudentItem), new PropertyMetadata(default(int)));

        public int Hours
        {
            get { return (int) GetValue(HoursProperty); }
            set { SetValue(HoursProperty, value); }
        }

        public static readonly DependencyProperty BeltProperty = DependencyProperty.Register(
            "Belt", typeof (Belt), typeof (StudentItem), new PropertyMetadata(default(Belt)));

        public Belt Belt
        {
            get { return (Belt) GetValue(BeltProperty); }
            set { SetValue(BeltProperty, value); }
        }

        public static readonly DependencyProperty BalanceDecimalProperty = DependencyProperty.Register(
            "BalanceDecimal", typeof (decimal), typeof (StudentItem), new PropertyMetadata(default(decimal)));

        public decimal BalanceDecimal
        {
            get { return (decimal) GetValue(BalanceDecimalProperty); }
            set { SetValue(BalanceDecimalProperty, value); }
        }

        public static readonly DependencyProperty MembershipEndDateProperty = DependencyProperty.Register(
            "MembershipEndDate", typeof (DateTime), typeof (StudentItem), new PropertyMetadata(default(DateTime)));

        public DateTime MembershipEndDate
        {
            get { return (DateTime) GetValue(MembershipEndDateProperty); }
            set { SetValue(MembershipEndDateProperty, value); }
        }


    }


}
