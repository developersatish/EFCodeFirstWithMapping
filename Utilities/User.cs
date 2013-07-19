using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFCodeFirstWithMapping.Utilities
{
    public class User
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Display(Name = "Name", Description = "First Name + Last Name.")]
        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Numbers and special characters are not allowed in the name.")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

    }
}