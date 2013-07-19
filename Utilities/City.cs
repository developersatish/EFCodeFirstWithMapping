using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFCodeFirstWithMapping.Utilities
{
    public class City
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Enter City")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }


    }
}