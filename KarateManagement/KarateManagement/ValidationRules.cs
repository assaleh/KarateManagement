﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KarateManagement
{
    public class NameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string name = value as string;
            if (name != null && name.Any(c => char.IsDigit(c)))
            {
                return new ValidationResult(false, "Invalid name");
            }

            return new ValidationResult(true, null);
        }
    }

    public class PostalCodeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;
            bool valid = Regex.IsMatch(input, @"^[a-zA-z]{1}\d[a-zA-z]{1} *\d{1}[a-zA-z]{1}\d{1}$");

            if (!string.IsNullOrEmpty(input) && !valid)
            {
                return new ValidationResult(false, "Invalid Postal Code");
            }

            return new ValidationResult(true, null);
        }
    }

    public class EmailValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;
            bool valid = Regex.IsMatch(input, @"^.+@.+\..+$");

            if (!string.IsNullOrEmpty(input) && !valid)
            {
                return new ValidationResult(false, "Invalid Email");
            }

            return new ValidationResult(true, null);
        }
    }

    public class HoursValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;
            int result;
            bool isNumber = Int32.TryParse(input, out result);


            if (isNumber && result >= 0)
            {
                return new ValidationResult(true, null);
            }

            return new ValidationResult(false, "Please enter a valid number");
        }
    }

    public class BalanceValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;
            decimal result;
            bool isNumber = Decimal.TryParse(input, out result);


            if (isNumber)
            {
                return new ValidationResult(true, null);
            }

            return new ValidationResult(false, "Please enter a valid number");
        }
    }

    public class PhoneNumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;
            bool valid = Regex.IsMatch(input, @"^\d?\(?\d{3}\)?-?\d{3}-?\d{4}$");

            if (!string.IsNullOrEmpty(input) && !valid)
            {
                return new ValidationResult(false, "Invalid Phone number");
            }

            return new ValidationResult(true, null);
        }
    }

    public class DateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime input = new DateTime();
            bool isValid = false;
            if (value != null)
            {
                input = (DateTime)value;
                isValid = true;
            }

            // True if date is valid and is after Jan 1, 1900
            if (isValid && input.CompareTo(new DateTime(1900, 1, 1)) > 0)
            {
                return new ValidationResult(true, null);

            }
            return new ValidationResult(false, "Invalid Date");
        }
    }
}
