using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;


namespace Razor.Models
{
    public static class DB
    {
        public static List<Customer> Customers { get; private set; }

        static DB()
        {
            Customers = new List<Customer>();
        }
    }

    public class Customer : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(typeof(DateTime), "1/1/2000", "1/1/3000", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime RenewalDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Id > 100)
            {
                yield return new ValidationResult("The Id cannot be greater than 100", new[] { "Id" });
            }
        }
    }
}