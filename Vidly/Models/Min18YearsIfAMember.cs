using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
            {
                return ValidationResult.Success;
            }
            
            if (customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate is required.");
            }

            var age = new DateTime(DateTime.Now.Subtract((DateTime)customer.Birthdate).Ticks).Year - 1;

            return (age >= 18) ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 years old to go on a membership");

        }
    }
}