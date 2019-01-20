using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dropdownlistmvc.Data
{
    public class Employee
    {
        public int  Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public  string LastName { get; set; }
        [Required]
        [DisplayName("Gender")]
        public int? GenderId { get; set; }
        [Required]
        [DisplayName("Salary")]
        public int Salary { get; set; }
        [DisplayName("Image")]
        public byte[] Image { get; set; }

        public virtual Gender Genders { get; set; }

        public virtual IEnumerable<Gender> GendersEnum { get; set; }
    }
}