using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    public class Contact
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name length must be between 3 and 50 characters")]
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [RegularExpression(@"\+375\d{9}", ErrorMessage = "Phone format is +375xxxxxxxxxx")]
        [Required(ErrorMessage = "Phone is required!")]
        public string Phone { get; set; }
    }
}